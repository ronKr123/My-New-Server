using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using System.Data.OleDb;
using Model;
using System.Collections.Generic;

namespace ViewModel
{
    public class UsersDB: PersonDB
    {

        public override BaseEntity NewEntity()
        {
            return new Users();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Users user = entity as Users;

            int city = (int)reader["cityCode"];
            user.CityCode = CityDB.SelectById(city);
            user.UserName = reader["userName"].ToString();
            user.UserPassword = reader["userPassword"].ToString();
            user.Email = reader["email"].ToString();
            user.PhoneNumber = reader["phoneNumber"].ToString();

            string favoriteBooksTxt = reader["favoriteBooksList"].ToString();

            BooksList favBooksList = new BooksList();
            try
            {
                if (!string.IsNullOrEmpty(favoriteBooksTxt))
                {
                    string[] numbersAsString = favoriteBooksTxt.Split(',');
                    foreach (string numberAsString in numbersAsString)
                    {
                        int bookId;
                        if (int.TryParse(numberAsString, out bookId))
                        {
                            Books book = BooksDB.SelectById(bookId);
                            if (book != null)
                            {
                                favBooksList.Add(book);
                            }
                        }
                    }
                }

                user.FavoriteBooksList = favBooksList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            base.CreateModel(user); 
            return user; 
        }


        public UsersList SelectAll()
        {
            command.CommandText = $"SELECT personTbl.id, personTbl.firstName, personTbl.lastName, personTbl.dateOfBirth, usersTbl.cityCode, usersTbl.userName, usersTbl.userPassword, usersTbl.email, usersTbl.phoneNumber, usersTbl.favoriteBooksList FROM (personTbl INNER JOIN usersTbl ON personTbl.id = usersTbl.id)";
            UsersList uList = new UsersList(base.Select());
            return uList;
        }

       

        static private UsersList list = new UsersList();

        public static Users SelectById(int id)
        {
            if (list.Count == 0)
            {
                UsersDB db = new UsersDB();
                list = db.SelectAll();
            }
            Users user = list.Find(item => item.Id == id);
            return user;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Users u = entity as Users;
            if (u != null)
            {
                string sqlStr = $"Insert into usersTbl (id, cityCode, userName, userPassword, email, phoneNumber, favoriteBooksList) Values (@uId , @cityCode , @userName , @userPass , @email , @phoneNumber, @favBooksListTxt ) ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@uId", u.Id));
                cmd.Parameters.Add(new OleDbParameter("@cityCode", u.CityCode.Id));
                cmd.Parameters.Add(new OleDbParameter("@userName", u.UserName));
                cmd.Parameters.Add(new OleDbParameter("@userPass", u.UserPassword));
                cmd.Parameters.Add(new OleDbParameter("@email", u.Email));
                cmd.Parameters.Add(new OleDbParameter("@phoneNumber", u.PhoneNumber));
                cmd.Parameters.Add(new OleDbParameter("@favBooksListTxt", "0"));
            }

        }


        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Users u = entity as Users;
            if (u != null)
            {
                string sqlStr = $"Update usersTbl Set cityCode = @cityCode , userName = @userName , " +
                    $"userPassword = @userPass , email = @email , phoneNumber = @phoneNumber, " +
                    $"favoriteBooksList = @favBooksListTxt  WHERE id = @uId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@cityCode", u.CityCode.Id));
                cmd.Parameters.Add(new OleDbParameter("@userName", u.UserName));
                cmd.Parameters.Add(new OleDbParameter("@userPass", u.UserPassword));
                cmd.Parameters.Add(new OleDbParameter("@email", u.Email));
                cmd.Parameters.Add(new OleDbParameter("@phoneNumber", u.PhoneNumber));
                cmd.Parameters.Add(new OleDbParameter("@favBooksListTxt", GetStringIdsBooks(u.FavoriteBooksList)));
                cmd.Parameters.Add(new OleDbParameter("@uId", u.Id));
            }
        }

        private string GetStringIdsBooks(BooksList booksList)
        {
            if (booksList != null && booksList.Count != 0)
            {
                List<int> bookIds = new List<int>();
                foreach (Books book in booksList)
                {
                    if (book != null)
                    {
                        bookIds.Add(book.Id);
                    }
                }

                string idString = string.Join(",", bookIds);
                return idString;
            }
            return "0";
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Users u = entity as Users;
            if (u != null)
            {
                string sqlStr = $"DELETE FROM usersTbl WHERE id = @uId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@uId", u.Id));
            }
        }


        public override void Insert(BaseEntity entity)
        {
            Users u = entity as Users;
            if (u != null)
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, u));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, u));
            }
        }

   
        public override void Update(BaseEntity entity)
        {
            Users u = entity as Users;
            if (u != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, u));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, u));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            Users u = entity as Users;
            if (u != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, u));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, u));
            }
        }


    }
}
