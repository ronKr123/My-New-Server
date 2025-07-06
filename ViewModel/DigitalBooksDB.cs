using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class DigitalBooksDB : BooksDB
    {
        public override BaseEntity NewEntity()
        {
            return new DigitalBooks();
        }

        public DigitalBooksList SelectAll()
        {
            command.CommandText = $"SELECT digitalBooksTbl.bookAudioFile, digitalBooksTbl.duration, bookTbl.bookName, bookTbl.genreCode, bookTbl.writerCode, bookTbl.pictureBook, bookTbl.dateOfPublishBook , bookTbl.id FROM (digitalBooksTbl INNER JOIN bookTbl ON digitalBooksTbl.id = bookTbl.id)";

            DigitalBooksList dList = new DigitalBooksList(base.Select());
            return dList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            DigitalBooks b = entity as DigitalBooks;

            b.BookAudioFile = reader["bookAudioFile"].ToString();

            string audioPathStr = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../../../ViewModel/AudioBooksFiles/" + reader["bookAudioFile"].ToString());

            b.AudioPath = audioPathStr;

            b.Duration = (int)reader["duration"];

            base.CreateModel(entity);
            return b;
        }

        public static string ConvertAudioFileToBase64(string filePath)
        {
            try
            {
                byte[] audioBytes = File.ReadAllBytes(filePath);

                string base64String = Convert.ToBase64String(audioBytes);

                return base64String;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting audio file to base64: {ex.Message}");
                return null;
            }
        }


        static private DigitalBooksList list = new DigitalBooksList();

        public static DigitalBooks SelectById(int id)
        {
            if (list.Count == 0)
            {
                DigitalBooksDB db = new DigitalBooksDB();
                list = db.SelectAll();
            }
            DigitalBooks book = list.Find(item => item.Id == id);
            return book;
        }


        
        

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            DigitalBooks b = entity as DigitalBooks;
            if (b != null)
            {
                string sqlStr = $"Insert into digitalBooksTbl (id, bookAudioFile, duration) Values (@bId , @bBookAudioFile , @bDuration ) ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@bId", b.Id));
                cmd.Parameters.Add(new OleDbParameter("@bBookAudioFile", b.BookAudioFile));
                cmd.Parameters.Add(new OleDbParameter("@bDuration", b.Duration));
            }
        }


        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            DigitalBooks b = entity as DigitalBooks;
            if (b != null)
            {
                string sqlStr = $"Update digitalBooksTbl Set bookAudioFile = @bBookAudioFile , duration = @bDuration WHERE id = @bId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@bBookAudioFile", b.BookAudioFile));
                cmd.Parameters.Add(new OleDbParameter("@bDuration", b.Duration));
                cmd.Parameters.Add(new OleDbParameter("@bId", b.Id));
            }
        }


        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            DigitalBooks b = entity as DigitalBooks;
            if (b != null)
            {
                string sqlStr = $"DELETE FROM digitalBooksTbl WHERE id = @bId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@bId", b.Id));
            }
        }


        public override void Insert(BaseEntity entity)
        {
            DigitalBooks b = entity as DigitalBooks;
            if (b != null)
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, b));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, b));
            }
        }

        public override void Update(BaseEntity entity)
        {
            DigitalBooks b = entity as DigitalBooks;
            if (b != null)
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, b));
            updated.Add(new ChangeEntity(base.CreateUpdateSQL, b));
        }

        public override void Delete(BaseEntity entity)
        {
            DigitalBooks b = entity as DigitalBooks;
            if (b != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, b));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, b));
            }
        }


    }
}
