using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person: BaseEntity
    {
        private string firstName;

        private string lastName;

        private DateTime dateOfBirth;
       
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

    }
}
