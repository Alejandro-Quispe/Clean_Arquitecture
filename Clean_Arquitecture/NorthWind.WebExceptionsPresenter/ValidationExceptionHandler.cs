using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public class ValidationExceptionHandler
    : ExecptionHamblerBase, IExceptionHamdler
    {
        public Task Hamble(ExceptionContext context)
        {
            var Exception = context.Exception as ValidationException;

            StringBuilder Builder = new StringBuilder();

            foreach (var Failure in Exception.Errors)
            {
                Builder.AppendLine(string.Format("propiedad: {0}.Error: {1}", Failure.PropertyName,
                    Failure.PropertyName, Failure.ErrorMessage));

            
            }


            return setresult(context, StatusCodes.Status400BadRequest, "Error en los datos de entrada", Builder.ToString());
        }
    }
}
