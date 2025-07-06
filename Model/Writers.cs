using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Writers: Person
    {
        private Genre genreWriting;

        private string linkToBiography;

        public Genre GenreWriting { get => genreWriting; set => genreWriting = value; }
        public string LinkToBiography { get => linkToBiography; set => linkToBiography = value; }

    }


}
