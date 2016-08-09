using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
