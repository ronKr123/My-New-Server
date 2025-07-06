using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Writers: BaseEntity
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private Genre genreWriting;
        private string linkToBiography;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public Genre GenreWriting { get => genreWriting; set => genreWriting = value; }
        public string LinkToBiography { get => linkToBiography; set => linkToBiography = value; }

    }
}
