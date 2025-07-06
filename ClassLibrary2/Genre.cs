using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Genre
    {
        private int id;
        private string genreName;

        public int Id { get => id; set => id = value; }
        public string GenreName { get => genreName; set => genreName = value; }

    }
}
