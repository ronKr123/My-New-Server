using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonDB: BaseDB
    {

        public override BaseEntity NewEntity()
        {
            return new Person();
        }


        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Person p = entity as Person;
         
            p.FirstName = reader["firstName"].ToString();
            p.LastName = reader["lastName"].ToString();

            if (reader["dateOfBirth"] != null)
            {
                p.DateOfBirth = DateTime.Parse(reader["dateOfBirth"].ToString());
            }

            base.CreateModel(p);

            return p;
        }


        public PersonList SelectAll()
        {
            command.CommandText = $"SELECT * FROM personTbl";
            PersonList pList = new PersonList(base.Select());
            return pList;   
        }




        static private PersonList list = new PersonList();

        public static Person SelectById(int id)
        {
            if (list.Count == 0)
            {
                PersonDB db = new PersonDB();
                list = db.SelectAll();
            }
            Person p = list.Find(item => item.Id == id);
            return p;
        }

     
        
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person p = entity as Person;
            if (p != null)
            {
                string sqlStr = $"Insert into personTbl (firstName, lastName, dateOfBirth) Values (@firstName , @lastName , @dateOfBirth) ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@firstName", p.FirstName));
                cmd.Parameters.Add(new OleDbParameter("@lastName", p.LastName));
                cmd.Parameters.Add(new OleDbParameter("@dateOfBirth", p.DateOfBirth));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person p = entity as Person;
            if (p != null)
            {
               
                string sqlStr = $"Update personTbl Set firstName = @firstName , lastName = @lastName , dateOfBirth = @dateOfBirth  WHERE id = @pId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@firstName", p.FirstName));
                cmd.Parameters.Add(new OleDbParameter("@lastName", p.LastName));
                cmd.Parameters.Add(new OleDbParameter("@dateOfBirth", p.DateOfBirth));
                cmd.Parameters.Add(new OleDbParameter("@pId", p.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person p = entity as Person;
            if (p != null)
            {
                string sqlStr = $"DELETE FROM personTbl WHERE id = @pId ";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pId", p.Id));
            }
        }


    }
}
