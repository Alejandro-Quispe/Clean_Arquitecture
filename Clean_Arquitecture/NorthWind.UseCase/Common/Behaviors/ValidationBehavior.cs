using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public Task<TResponse> Handle(TRequests request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            // lanzar los validadores
            var Failures = Validators.Select(v => v.Validate(request))
                     .SelectMany(r => r.Errors)
                     .Where(f =>f != null)
                     .ToList();
            if(Failures.Any())    
            {
                throw new ValidationException(Failures);
            }
            return next();
        }
    }
}
