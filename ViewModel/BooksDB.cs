using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BooksDB : BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Books();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Books b = entity as Books;
            b.BookName = reader["bookName"].ToString();
            int codeGenre = (int)reader["genreCode"];
            b.GenreCode = GenreDB.SelectById(codeGenre);
            b.PictureBook = reader["pictureBook"].ToString();

            if (reader["dateOfPublishBook"] != null)
            {
                b.DateOfPublishBook = DateTime.Parse(reader["dateOfPublishBook"].ToString());
            }

            int writerCode = (int)reader["writerCode"];
            b.WriterCode = WritersDB.SelectById(writerCode);

            string imagePath = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location 
                + "/../../../../../ViewModel/BooksPictures/" + reader["pictureBook"].ToString());

            string base64String = ImageToBase64Converter.ImageToBase64(imagePath);
            b.BookPic = base64String;
        
            base.CreateModel(entity);
            return b;
        }


        public BooksList SelectAll()
        {
            command.CommandText = $"Select * From bookTbl";

            BooksList bList = new BooksList(base.Select());
            return bList;
        }

        

        public BooksList SelectAllWithFilter(string sqlSentence)
        {
            this.command.CommandText = sqlSentence;
            BooksList booksList = new BooksList(base.Select());
            return booksList;
        }
       


        static private BooksList list = new BooksList();

        public static Books SelectById(int id)
        {
            if (list.Count == 0)
            {
                BooksDB db = new BooksDB();
                list = db.SelectAll();
            }
            Books book = list.Find(item => item.Id == id);
            return book;
        }

        public string SelectBookPicByBookId(int id)
        {
            BooksList booksList = SelectAll();
            Books book = booksList.Find(x => x.Id == id);
            string pic = book.BookPic;
            return pic;
        }


        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Books b = entity as Books;
            if (b != null)
                {
                  string sqlStr = $"INSERT into bookTbl (bookName , genreCode , writerCode , pictureBook , dateOfPublishBook ) VALUES (@bookName , @genreCode , @writerCode , @pictureBook , @dateOfPublishBook )";

                   cmd.CommandText = sqlStr;

                   cmd.Parameters.Add(new OleDbParameter("@bookName", b.BookName));
                   cmd.Parameters.Add(new OleDbParameter("@genreCode", b.GenreCode.Id));
                   cmd.Parameters.Add(new OleDbParameter("@writerCode", b.WriterCode.Id));
                   cmd.Parameters.Add(new OleDbParameter("@pictureBook", b.PictureBook));
                   cmd.Parameters.Add(new OleDbParameter("@dateOfPublishBook", b.DateOfPublishBook));
                }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Books b = entity as Books;
            if (b != null)
            {
                string sqlStr = $"Update bookTbl Set bookName = @bookName , genreCode = @genreCode , writerCode= @writerCode , pictureBook= @pictureBook , dateOfPublishBook = @dateOfPublishBook  WHERE id = @bId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@bookName", b.BookName));
                cmd.Parameters.Add(new OleDbParameter("@genreCode", b.GenreCode.Id));
                cmd.Parameters.Add(new OleDbParameter("@writerCode", b.WriterCode.Id));
                cmd.Parameters.Add(new OleDbParameter("@pictureBook", b.PictureBook));
                cmd.Parameters.Add(new OleDbParameter("@dateOfPublishBook", b.DateOfPublishBook));
                cmd.Parameters.Add(new OleDbParameter("@bId", b.Id));
            }

        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Books b = entity as Books;
            if (b != null)
            {
                string sqlStr = $"DELETE FROM bookTbl WHERE id = @bId";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@bId", b.Id));
            }
        }


        public override void Insert(BaseEntity entity)
        {
            Books b = entity as Books;
            if (b != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, b));
            }
        }


        public override void Update(BaseEntity entity)
        {
            Books b = entity as Books;
            if (b != null)
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, b));
        }


        public override void Delete(BaseEntity entity)
        {
            Books b = entity as Books;
            if (b != null)
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, b));
        }




    }

    public class ImageToBase64Converter
    {
        public static string ImageToBase64(string imagePath)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error converting image to base64 : " + ex.Message);
                return string.Empty;
            }
        }
    }

}
