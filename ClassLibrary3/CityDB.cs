using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class CityDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student.HP-6KHJCV2\source\repos\Model\ViewModel\LibraryDataBase.accdb";
        private OleDbConnection connection;
        private OleDbCommand command;
        private OleDbDataReader reader;

        static private CityList list = new CityList();

        public CityDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public CityList SelectAll()
        {
            command.CommandText = "Select * From cityTbl";

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                City c;
                while (reader.Read())
                {
                    c = new City();
                    c.Id = (int)reader["id"];
                    c.CityName = reader["cityName"].ToString();
                    list.Add(c);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return list;
        }

        public static City SelectById(int id)
        {
            if(list.Count == 0)
            {
                CityDB db = new CityDB();
                list = db.SelectAll();
            }
            City city = list.Find(item => item.Id == id);
            return city;
        }


    }
}
