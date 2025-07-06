using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Books: BaseEntity
    {
		public string BookName { get; set; } = string.Empty;

		public Genre GenreCode { get; set; } = new Genre();

		public Writers WriterCode { get; set; } = new Writers();

		public string PictureBook { get; set; } = string.Empty;

		public DateTime DateOfPublishBook { get; set; } = DateTime.Now;

		public string BookPic { get; set; } = string.Empty;

	}
}
