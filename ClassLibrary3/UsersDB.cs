using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class UsersDB
    {

        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Student.HP-6KHJCV2\source\repos\Model\ViewModel\LibraryDataBase.accdb";
        private OleDbConnection connection;
        private OleDbCommand command;
        private OleDbDataReader reader;


        public UsersDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }


        public UsersList SelectAll()
        {
            command.CommandText = "Select * From usersTbl";
            UsersList usersList = new UsersList();
            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                Users user;
                while (reader.Read())
                {
                    user = new Users();
                    user.Id = (int)reader["id"];
                    user.FirstName = reader["firstName"].ToString();
                    user.LastName = reader["lastName"].ToString();
                    user.DateOfBirth = DateTime.Parse(reader["dateOfBirth"].ToString());
                    int city = (int)reader["cityCode"];
                    user.CityCode = CityDB.SelectById(city);
                    user.UserName = reader["userName"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Email = reader["email"].ToString();
                    user.PhoneNumber = reader["phoneNumber"].ToString();
                    usersList.Add(user);
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return usersList;
        }







    }
}
