using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LendingAndReturnsBooksDB: BaseDB
    {

        public override BaseEntity NewEntity()
        {
            return new LendingAndReturnsBooks();
        }
       

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            LendingAndReturnsBooks lendAndRet = entity as LendingAndReturnsBooks;
            int codeUser = (int)reader["userCode"];
            lendAndRet.UserCode = UsersDB.SelectById(codeUser);

            int bookCode = (int)reader["bookCode"];
            lendAndRet.BookCode = BooksDB.SelectById(bookCode);

            if (reader["dateOfLending"] != null)
            {
                lendAndRet.DateOfLending = DateTime.Parse(reader["dateOfLending"].ToString());
            }

            if (reader["dateOfReturn"] != null)
            {
                lendAndRet.DateOfReturn = DateTime.Parse(reader["dateOfReturn"].ToString());
            }

            base.CreateModel(entity);
            return lendAndRet;
        }


        public LendingAndReturnsBooksList SelectAll()
        {
            command.CommandText = $"SELECT lendingAndReturnsBooksTbl.id, lendingAndReturnsBooksTbl.userCode, lendingAndReturnsBooksTbl.dateOfLending, lendingAndReturnsBooksTbl.bookCode, lendingAndReturnsBooksTbl.dateOfReturn, bookTbl.bookName, bookTbl.genreCode, bookTbl.writerCode, bookTbl.pictureBook, bookTbl.dateOfPublishBook , usersTbl.cityCode, usersTbl.userName, usersTbl.userPassword, usersTbl.email, usersTbl.phoneNumber, usersTbl.favoriteBooksList FROM ((lendingAndReturnsBooksTbl INNER JOIN bookTbl ON lendingAndReturnsBooksTbl.bookCode = bookTbl.id) INNER JOIN usersTbl ON lendingAndReturnsBooksTbl.userCode = usersTbl.id)";
            LendingAndReturnsBooksList LendAndRetList = new LendingAndReturnsBooksList(base.Select());
            return LendAndRetList;
        }



        static private LendingAndReturnsBooksList list = new LendingAndReturnsBooksList();

        public static LendingAndReturnsBooks SelectById(int id)
        {
            if (list.Count == 0)
            {
                LendingAndReturnsBooksDB db = new LendingAndReturnsBooksDB();
                list = db.SelectAll();
            }
            LendingAndReturnsBooks lendAndRet = list.Find(item => item.Id == id);
            return lendAndRet;
        }


        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            LendingAndReturnsBooks l = entity as LendingAndReturnsBooks;
            if (l != null)
            {
                string sqlStr = $"Insert into lendingAndReturnsBooksTbl (userCode, bookCode, dateOfLending, dateOfReturn) Values (@lUserCode , @lbookCode , @lDateOfLending , @lDateOfReturn ) ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@lUserCode", l.UserCode.Id));
                cmd.Parameters.Add(new OleDbParameter("@lbookCode", l.BookCode.Id));
                cmd.Parameters.Add(new OleDbParameter("@lDateOfLending", l.DateOfLending));
                cmd.Parameters.Add(new OleDbParameter("@lDateOfReturn", l.DateOfReturn));
            }
        }


        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            LendingAndReturnsBooks l = entity as LendingAndReturnsBooks;
            if (l != null)
            {
                string sqlStr = $"Update lendingAndReturnsBooksTbl Set userCode = @lUserCode , bookCode = @lbookCode , dateOfLending = @lDateOfLending , dateOfReturn = @lDateOfReturn  WHERE id = @lId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@lUserCode", l.UserCode.Id));
                cmd.Parameters.Add(new OleDbParameter("@lbookCode", l.BookCode.Id));
                cmd.Parameters.Add(new OleDbParameter("@lDateOfLending", l.DateOfLending));
                cmd.Parameters.Add(new OleDbParameter("@lDateOfReturn", l.DateOfReturn));
                cmd.Parameters.Add(new OleDbParameter("@lId", l.Id));
            }
        }


        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            LendingAndReturnsBooks l = entity as LendingAndReturnsBooks;
            if (l != null)
            {
                string sqlStr = $"DELETE FROM lendingAndReturnsBooksTbl WHERE id = @lId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@lId", l.Id));
            }
        }


        public override void Insert(BaseEntity entity)
        {
            LendingAndReturnsBooks l = entity as LendingAndReturnsBooks;
            if (l != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, l));
            }
        }

        public override void Update(BaseEntity entity)
        {
            LendingAndReturnsBooks l = entity as LendingAndReturnsBooks;
            if (l != null)
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, l));
        }

        public override void Delete(BaseEntity entity)
        {
            LendingAndReturnsBooks l = entity as LendingAndReturnsBooks;
            if (l != null)
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, l));
        }

    }
}
