using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCase.CreateOrder
{
   public  class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
   {

        public CreateOrderValidator()
        { 
            // no debe estar vacio
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("Debe proporcionar el identificador del cliente ");
            RuleFor(c => c.ShipAddress).NotEmpty().WithMessage("debe proporcionar direccion enviada");
            //RuleFor(c => c.ShipCity).NotEmpty().MinimumLength(3).WhitMessage("debe proporcionar al menos 3 caracteres de nombre de la ciudad");
            RuleFor(c => c.Orderdetails)
            .Must(d => d != null && d.Any())
            .WithMessage("Deben especificarse los productos de la orden");
        }

    }
}
