using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Exceptions
{
    public class GeneralExceptions : Exception
    {

        public string Detail { get; set; }
        public GeneralExceptions()  {}

        public GeneralExceptions(String message) : base(message) { }

        public GeneralExceptions(String message,Exception innerExptions) : base(message, innerExptions) { }
        public GeneralExceptions(String title, string detail) : base(title) => Detail = detail;

    }
}
