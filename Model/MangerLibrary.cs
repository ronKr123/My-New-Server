using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MangerLibrary: Person
    {
        private string mangerUserName;

        private string mangerPass;

        public string MangerUserName { get => mangerUserName; set => mangerUserName = value; }
        public string MangerPass { get => mangerPass; set => mangerPass = value; }

    }
}
