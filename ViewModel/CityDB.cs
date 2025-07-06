using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model;
using System.Reflection.Metadata;

namespace ViewModel
{
    public class CityDB: BaseDB
    {


        static private CityList list = new CityList();


        public override BaseEntity NewEntity()
        {
            return new City();
        }



        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City c = entity as City;
            c.CityName = reader["cityName"].ToString();
            base.CreateModel(entity);
            return c;
        }


        public CityList SelectAll()
        {
            command.CommandText = $"SELECT * FROM cityTbl";
            CityList cList = new CityList(base.Select());
            return cList;
        }


        public static City SelectById(int id)
        {
            if (list.Count == 0)
            {
                CityDB db = new CityDB();
                list = db.SelectAll();
            }
            City city = list.Find(item => item.Id == id);
            return city;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City city = entity as City;
            if (city != null)
            {
                string sqlStr = $"INSERT INTO cityTbl (cityName) " +
                                $" Values (@cName)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@cName", city.CityName));
            }

        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City city = entity as City;

            string sqlStr = $"UPDATE cityTbl SET CityName=@cCityName " +
                $" WHERE id = @cId";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@cCityName", city.CityName));
            cmd.Parameters.Add(new OleDbParameter("@cId", city.Id));

        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City city = entity as City;
            string sqlStr = $"DELETE FROM cityTbl WHERE id = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", city.Id));

        }


        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity)); 
            }

        }

        public override void Update(BaseEntity entity)
        {
            City city = entity as City;
            if (city != null)
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, city));
        }

        public override void Delete(BaseEntity entity)
        {
            City city = entity as City;
            if (city != null)
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, city));
        }

        
    }
}
