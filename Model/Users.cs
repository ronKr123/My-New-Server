using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users :  Person
    {
		public City CityCode { get; set; } = null!; // או אתחל לפי הצורך
		public string UserName { get; set; } = string.Empty;
		public string UserPassword { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public BooksList FavoriteBooksList { get; set; } = new BooksList();

	}
}
