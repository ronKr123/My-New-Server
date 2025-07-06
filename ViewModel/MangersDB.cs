using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace ViewModel
{
    public class MangersDB: PersonDB
    {
        public override BaseEntity NewEntity()
        {
            return new MangerLibrary();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MangerLibrary manger = entity as MangerLibrary;
            manger.MangerUserName = reader["mangerUserName"].ToString();
            manger.MangerPass = reader["mangerPass"].ToString();
            base.CreateModel(manger);
            return manger;
        }

        public MangerLibraryList SelectAll()
        {
            command.CommandText = $"SELECT personTbl.id, personTbl.firstName, personTbl.lastName, personTbl.dateOfBirth, MangersLibraryTbl.mangerUserName, MangersLibraryTbl.mangerPass FROM (personTbl INNER JOIN MangersLibraryTbl ON personTbl.id = MangersLibraryTbl.id)";
            MangerLibraryList mangers = new MangerLibraryList(base.Select());
            return mangers;
        }

        static private MangerLibraryList list = new MangerLibraryList();

        public static MangerLibrary SelectById(int id)
        {
            if (list.Count == 0)
            {
                MangersDB db = new MangersDB();
                list = db.SelectAll();
            }
            MangerLibrary manger = list.Find(item => item.Id == id);
            return manger;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MangerLibrary m = entity as MangerLibrary;
            if (m != null)
            {
                string sqlStr = $"Insert into MangersLibraryTbl (id, mangerUserName, mangerPass) Values (@mId , @mUserName , @mPass)";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@mId", m.Id));
                cmd.Parameters.Add(new OleDbParameter("@mUserName", m.MangerUserName));
                cmd.Parameters.Add(new OleDbParameter("@mPass", m.MangerPass));
            }
        }



        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MangerLibrary m = entity as MangerLibrary;
            if (m != null)
            {
                string sqlStr = $"Update MangersLibraryTbl Set mangerUserName = @mUserName , mangerPass = @mPass WHERE id = @mId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@mUserName", m.MangerUserName));
                cmd.Parameters.Add(new OleDbParameter("@mPass", m.MangerPass));
                cmd.Parameters.Add(new OleDbParameter("@mId", m.Id));
            }
        }


        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MangerLibrary m = entity as MangerLibrary;
            if (m != null)
            {
                string sqlStr = $"DELETE FROM MangersLibraryTbl WHERE id = @mId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@mId", m.Id));
            }
        }


        public override void Insert(BaseEntity entity)
        {
            MangerLibrary m = entity as MangerLibrary;
            if (m != null)
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, m));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, m));
            }
        }

        public override void Update(BaseEntity entity)
        {
            MangerLibrary m = entity as MangerLibrary;
            if (m != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, m));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, m));
            }
        }

        public override void Delete(BaseEntity entity)
        {
            MangerLibrary m = entity as MangerLibrary;
            if (m != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, m));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, m));
            }
        }

    }
}
