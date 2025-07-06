using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BooksList: List<Books>
    {
        public BooksList() { }

        public BooksList(IEnumerable<Books> list) : base(list) { }

        public BooksList(IEnumerable<BaseEntity> list) : base(list.Cast<Books>().ToList()) { }

    }
}
