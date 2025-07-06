using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Writers: Person
    {
		public Genre GenreWriting { get; set; } = null!; // או אפשר לשים GenreWriting? אם יכול להיות ריק
		public string LinkToBiography { get; set; } = string.Empty;

	}


}
