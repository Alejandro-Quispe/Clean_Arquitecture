using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// proporciona los datos webasembly
namespace NorthWind.UseCasesDTOs.CreateOrder
{
   public class CreateOrderParams
    {

        public String CustomerId { get; set; }
        public String ShipAddress { get; set; }
        public String ShipCity { get; set; }

        public String ShipCountry { get; set; }

        public String ShipPostalCode { get; set; }

        public List<CreateOrderDetailParams> Orderdetails { get; set; }

    }
}
