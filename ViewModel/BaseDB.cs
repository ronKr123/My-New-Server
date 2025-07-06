using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Diagnostics;
using System.IO;

namespace ViewModel
{

    public abstract class BaseDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + 
            System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location 
                + "/../../../../../ViewModel/LibraryDataBase.accdb");
        protected static OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        public abstract BaseEntity NewEntity();

        

        public BaseDB()
        {
            connection ??= new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;

        }




        protected virtual BaseEntity CreateModel(BaseEntity entity)
        {
            entity.Id = (int)reader["id"];
            return entity;
        }


        public static List<ChangeEntity> inserted = new List<ChangeEntity>();
        public static List<ChangeEntity> deleted = new List<ChangeEntity>();
        public static List<ChangeEntity> updated = new List<ChangeEntity>();


      
        protected abstract void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);




        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity)); ;
            }
        }

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }





        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            return list;
        }





        public int SaveChanges()
        {
            int records_affected = 0;
            OleDbTransaction trans = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
               
                trans = connection.BeginTransaction();
                command.Transaction = trans;


                foreach (var item in inserted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    item.Entity.Id = (int)command.ExecuteScalar();
                }

                
                foreach (var item in updated)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += command.ExecuteNonQuery();
                }

                foreach (var item in deleted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += command.ExecuteNonQuery();
                }

                trans.Commit();

            }
            catch (Exception e)
            {
                trans.Rollback();

                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);

            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

                if (reader != null)
                    reader.Close();
               
            }
            return records_affected;
        }



       



    }
}
