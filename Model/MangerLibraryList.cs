using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MangerLibraryList: List<MangerLibrary>
    {
		public MangerLibraryList() : base() { }

		public MangerLibraryList(IEnumerable<MangerLibrary> list) : base(list) { }

		public MangerLibraryList(IEnumerable<BaseEntity> list) : base(list.OfType<MangerLibrary>()) { }

	}
}
