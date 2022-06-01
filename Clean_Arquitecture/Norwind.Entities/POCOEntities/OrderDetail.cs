using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norwind.Entities.POCOEntities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UniPrice { get; set; }


        public short Quantity { get; set; }


        public Order Order { get; set; }


    }
}
