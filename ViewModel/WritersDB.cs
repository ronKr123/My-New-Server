using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WritersDB : PersonDB
    {
        public override BaseEntity NewEntity()
        {
            return new Writers();
        }
       

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Writers w = entity as Writers;

            int genreCode = (int)reader["genreWriting"];

            w.GenreWriting = GenreDB.SelectById(genreCode);

            w.LinkToBiography = reader["linkToBiography"].ToString();

            base.CreateModel(entity); 

            return w; 
        }


        public WritersList SelectAll()
        {
            command.CommandText = $"SELECT personTbl.id, personTbl.firstName, " +
                $"personTbl.lastName, personTbl.dateOfBirth, " +
                $"writersTbl.genreWriting, writersTbl.linkToBiography" +
                $" FROM (writersTbl INNER JOIN personTbl ON writersTbl.id = personTbl.id)";
            WritersList wList = new WritersList(base.Select());
            return wList;
        }



        static private WritersList list = new WritersList();

        public static Writers SelectById(int id)
        {
            if (list.Count == 0)
            {
                WritersDB db = new WritersDB();
                list = db.SelectAll();
            }
            Writers writer = list.Find(item => item.Id == id);
            return writer;
        }

      
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Writers w = entity as Writers;
            if (w != null)
            {
                string sqlStr = $"Insert into writersTbl (id, genreWriting , linkToBiography) Values (@wId , @wGenreWritingId , @wLinkToBiography ) ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@wId", w.Id));
                cmd.Parameters.Add(new OleDbParameter("@wGenreWritingId", w.GenreWriting.Id));
                cmd.Parameters.Add(new OleDbParameter("@wLinkToBiography", w.LinkToBiography));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Writers w = entity as Writers;
            if (w != null)
            {
                string sqlStr = $"Update writersTbl Set genreWriting = @wGenreWritingId , linkToBiography = @wLinkToBiography WHERE id = @wId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@wGenreWritingId", w.GenreWriting.Id));
                cmd.Parameters.Add(new OleDbParameter("@wLinkToBiography", w.LinkToBiography));
                cmd.Parameters.Add(new OleDbParameter("@wId", w.Id));

            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Writers w = entity as Writers;
            if (w != null)
            {
                string sqlStr = $"DELETE FROM writersTbl WHERE id = @wId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@wId", w.Id));
            }
        }


        public override void Insert(BaseEntity entity)
        {
            Writers w = entity as Writers;
            if (w != null)
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, w));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, w));
            }
        }

        public override void Update(BaseEntity entity)
        {
            Writers w = entity as Writers;
            if (w != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, w));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, w));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            Writers w = entity as Writers;

            if (w != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, w));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, w));
            }
        }


    }
}
