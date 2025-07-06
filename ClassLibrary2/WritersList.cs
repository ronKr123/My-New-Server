using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WritersList: List<Writers>
    {
        public WritersList() { }

        public WritersList(IEnumerable<Writers> list) : base(list) { }

        public WritersList(IEnumerable<BaseEntity> list) : base(list.Cast<Writers>().ToList()) { }

    }
}
