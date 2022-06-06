using MediatR;
using NorthWind.UseCasesDTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCase.CreateOrder
{
    // devuelve una orden
    // hereda createorderparams para no duplicar
    public class CreateOrderInputPort : CreateOrderParams, IRequest<int>
    {
        // devuel el numero de la orden




    }
}
