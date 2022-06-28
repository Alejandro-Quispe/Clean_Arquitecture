using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Repositories.EFCore.DataContext;
using NorthWind.Repositories.EFCore.Repositories;
using NorthWind.UseCase.CreateOrder;
using Norwind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.IoC
{
  public static class DependencyContainer
    {

        public static IServiceCollection AddNorthWindServices(

            this IServiceCollection service, 
            IConfiguration configuration)

        {
            service.AddDbContext<NorthWindContext>(options => options.UseSqlServer(configuration.GetConnectionString("NorthWinDB")));
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            service.AddScoped<IUnitOfwork, UnitOfWork>();

            service.AddMediatR(typeof(CreateOrderInteractor));
            service.AddValidatorsFromAssembly(typeof(CreateOrderInteractor).Assembly);
            service.AddTransient(typeof(IPipelineBehavior<,>));

            return service;



        
        }


    }
}
