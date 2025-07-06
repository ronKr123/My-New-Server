using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LendingAndReturnsBooks: BaseEntity
    {

		public Users UserCode { get; set; } = null!; // null! כדי להודיע לקומפיילר שזה יאותחל במקומות אחרים
		public Books BookCode { get; set; } = null!;
		public DateTime DateOfLending { get; set; }
		public DateTime DateOfReturn { get; set; }


	}
}
