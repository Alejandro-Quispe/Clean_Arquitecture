using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
  public  class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly IDictionary<Type, IExceptionHamdler> ExceptionHandler;

        public ApiExceptionFilterAttribute(
           IDictionary<Type, IExceptionHamdler> exceptionHandlers) =>
            ExceptionHandler = exceptionHandlers;
        public override void OnException(ExceptionContext context)
        {
            Type ExceptionType = context.Exception.GetType();
            if (ExceptionHandler.ContainsKey(ExceptionType))
            {

                ExceptionHandler[ExceptionType].Hamble(context);
            }
            else {

                new ExecptionHamblerBase().setresult(context, StatusCodes.Status500InternalServerError, "Ha ocurrido un error al procesar la respuesta.", "");

            
            }

            base.OnException(context);

        }



    }
}
