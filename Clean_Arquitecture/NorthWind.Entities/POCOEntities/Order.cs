using NorthWind.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.POCOEntities
{
    public class Order 
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public String  ShipAdddress { get; set; }
        public String ShipCity { get; set; }
        public String ShipContry { get; set; }
        public String ShipPostalCode { get; set; }

        public DiscountType DiscountType { get; set; }
        public double Discount { get; set; }

        public ShippingType ShippingType { get; set; }

    }
}
