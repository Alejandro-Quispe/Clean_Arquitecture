using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.DataContext
{
    public class NorthWindContext : DBContext
    {
        public NorthWindContext(
            DBContext<NorthWindContext> options) : base(options) { }




    }

    public class DBContext<T>
    {
    }

    public class DBContext
    {
        public DBContext(DBContext options)
        {
        }

        public DBContext(DBContext<NorthWindContext> options)
        {
            Options = options;
        }

        public DBContext<NorthWindContext> Options { get; }
    }
}
