using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Norwind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
   public class GeneralExceptionHambler : ExecptionHamblerBase,IExceptionHamdler
    {
        public Task Hamble(ExceptionContext context)
        {
            var Exception = context.Exception as GeneralException;
            return setresult(context, StatusCodes.Status500InternalServerError, Exception.Message, Exception.Detail
                );
        }
 


    }
}
