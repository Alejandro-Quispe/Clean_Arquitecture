using NorthWind.Repositories.EFCore.DataContext;
using Norwind.Entities.Interfaces;
using Norwind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository

    {
        readonly NorthWindContext Context;
        public OrderDetailRepository(NorthWindContext context) =>
            Context = context;

        public void Create(OrderDetail orderDetail)
        {
            Context.Add(orderDetail);
        }
    }
}
