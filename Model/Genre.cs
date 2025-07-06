using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Genre : BaseEntity
    {
       private string genreName;

       public string GenreName { get => genreName; set => genreName = value; }

    }
}
