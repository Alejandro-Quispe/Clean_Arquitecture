using MediatR;
using Norwind.Entities.Interfaces;
using Norwind.Entities.POCOEntities;
using Norwind.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.UseCase.CreateOrder
{
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfwork UnitOfwork;

        public CreateOrderInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository
            , IUnitOfwork unitOfwork) =>
            (OrderRepository, OrderDetailRepository, UnitOfwork) = 
            (orderRepository, orderDetailRepository, unitOfwork);
 

        public async Task<int> Handle(CreateOrderInputPort request, 
            CancellationToken cancellationToken)
        {
            Order Order = new Order
            { 
            
                customerId=request.CustomerId,
                OrderDate=DateTime.Now,
                ShipAddress=request.ShipAddress,
                ShipCity=request.ShipCity,
                ShipCountry=request.ShipCountry,
                ShipPostalCode=request.ShipPostalCode,
                shippingType= Entities.enums.DyscountType,

           
            
            }


        }
    }
}
