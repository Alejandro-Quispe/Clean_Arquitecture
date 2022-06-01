using Norwind.Entities.POCOEntities;
using Norwind.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norwind.Entities.Interfaces
{
   public interface IOrderRepository
    {

        void Create(Order order);

        IEnumerable<Order> GetOrdersByspecification(Specification<Order> specification);



    }
}
