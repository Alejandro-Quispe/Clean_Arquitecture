using NorthWind.Repositories.EFCore.DataContext;
using Norwind.Entities.Interfaces;
using Norwind.Entities.POCOEntities;
using Norwind.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // recibir el conexto de datos
        readonly NorthWindContext Context;

        // lo inyectamos
        public OrderRepository(NorthWindContext context) =>
            Context=context;


        public void Create(Order order)
        {

            Context.Add(order);
        }

        public IEnumerable<Order> GetOrdersByspecification(Specification<Order> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return Context.Orders.Where(ExpressionDelegate);

        }
    }
}
