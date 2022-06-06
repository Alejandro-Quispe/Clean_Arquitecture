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
using Norwind.Entities.Exceptions;

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

                customerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPostalCode,
                shippingType = Norwind.Entities.Enums.ShippingType.Road,
                DiscountType = Norwind.Entities.Enums.DiscountType.Percentage,
                Discount = 10

            };

            OrderRepository.Create(Order);
            foreach (var Item in request.Orderdetails)
            {
                OrderDetailRepository.Create(

                    new OrderDetail
                    {
                        Order = Order,
                        ProductId = Item.ProductId,
                        UniPrice = Item.UnitPrice,
                        Quantity = Item.Quantity

                    });

            }
            try
            {
                await UnitOfwork.SaveChangesAsync();

            }
                   catch(Exception ex)
                {
                throw new GeneralException("Error al crear la orden",ex.Message)


                 }
            return Order.Id;
            }

        }
    }

