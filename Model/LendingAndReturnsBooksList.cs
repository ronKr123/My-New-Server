using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LendingAndReturnsBooksList : List<LendingAndReturnsBooks>
    {
		public LendingAndReturnsBooksList() : base() { }

		public LendingAndReturnsBooksList(IEnumerable<LendingAndReturnsBooks> list) : base(list) { }

		public LendingAndReturnsBooksList(IEnumerable<BaseEntity> list) : base(list.OfType<LendingAndReturnsBooks>()) { }

	}
}
