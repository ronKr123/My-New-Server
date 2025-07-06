using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CityList: List<City>
    {
		public CityList() : base() { }

		public CityList(IEnumerable<City> list) : base(list) { }

		public CityList(IEnumerable<BaseEntity> list) : base(list.OfType<City>()) { }

	}
}
