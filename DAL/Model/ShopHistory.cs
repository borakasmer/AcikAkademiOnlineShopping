using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ShopHistory
    {
        public int id { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
