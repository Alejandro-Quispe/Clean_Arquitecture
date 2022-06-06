using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCase.Common.Behaviors
{
   public class ValidationBehavior<TRequests, TResponse>: 
        IPipelineBehavior<TRequests,TResponse>
        where TRequests: IRequest<TResponse >
    {

        readonly IEnumerable<IValidator<TRequests>> Validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequests>> validators) =>
            Validators = validators;
    }
}
