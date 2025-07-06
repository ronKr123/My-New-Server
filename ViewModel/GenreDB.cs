using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class GenreDB: BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Genre();
        }


        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Genre g = entity as Genre;
            g.GenreName = reader["genreName"].ToString();
            base.CreateModel(entity);
            return g;
        }

                
        public GenreList SelectAll()
        {
            command.CommandText = $"SELECT * FROM genereTbl";
            GenreList gList = new GenreList(base.Select());
            return gList;
        }


        static private GenreList list = new GenreList();

        public static Genre SelectById(int id)
        {
            if (list.Count == 0)
            {
                GenreDB db = new GenreDB();
                list = db.SelectAll();
            }
            Genre genre = list.Find(item => item.Id == id);
            return genre;
        }


        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre genre = entity as Genre;
            if (genre != null)
            {
                string sqlStr = $"INSERT INTO genereTbl (genreName) Values (@gName)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@gName", genre.GenreName));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre genre = entity as Genre;
            if (genre != null)
            {
                string sqlStr = $"Update genereTbl SET genreName=@gName WHERE id = @gId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@gName", genre.GenreName));
                cmd.Parameters.Add(new OleDbParameter("@gId", genre.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre genre = entity as Genre;
            if(genre != null)
            {
                string sqlStr = $"DELETE FROM genereTbl WHERE id = @gId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@gId", genre.Id));
            }
        }

        public override void Insert(BaseEntity entity)
        {
            Genre g = entity as Genre;
            if (g != null)
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, g));
            }
        }

        public override void Update(BaseEntity entity)
        {
            Genre g = entity as Genre;
            if (g != null)
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, g));
        }

        public override void Delete(BaseEntity entity)
        {
            Genre g = entity as Genre;
            if (g != null)
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, g));
        }

       
    }
}
