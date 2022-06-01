using NorthWind.Repositories.EFCore.DataContext;
using Norwind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfwork

    {
        readonly NorthWindContext Context;

        public UnitOfWork(NorthWindContext context) => Context = context;

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
            
        }
    }
}
