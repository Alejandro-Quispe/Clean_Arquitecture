using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Repositories.EFCore.DataContext;
using NorthWind.Repositories.EFCore.Repositories;
using NorthWind.UseCase.Common.Behaviors;
using NorthWind.UseCase.CreateOrder;
using Norwind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace NorthWind.IoC
{
  public static  class DependencyContainer
    {


        public static IServiceCollection AddNorthWindService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<NorthWindContext>(option => option.UseSqlServer(configuration.GetConnectionString("NorthWindDB")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfwork, UnitOfWork>();
            services.AddMediatR(typeof(CreateOrderInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;


        

        }

    }
}
