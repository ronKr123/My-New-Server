using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class City
    {
        private int id;
        private string cityName;

        public int Id { get => id; set => id = value; }
        public string CityName { get => cityName; set => cityName = value; }
    }
}
