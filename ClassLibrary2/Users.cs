using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users: BaseEntity
    {
        private string firstName;
        private string lastName;
        private City cityCode;
        private string userName;
        private string password; 
        private string email;   
        private string phoneNumber;
        private DateTime dateOfBirth;


        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public City CityCode { get => cityCode; set => cityCode = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
    }
}
