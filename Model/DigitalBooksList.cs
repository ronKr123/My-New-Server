using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DigitalBooksList: List<DigitalBooks>
    {
		public DigitalBooksList() : base() { }

		public DigitalBooksList(IEnumerable<DigitalBooks> list) : base(list) { }

		public DigitalBooksList(IEnumerable<BaseEntity> list) : base(list.OfType<DigitalBooks>()) { }

	}
}
