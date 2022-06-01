﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norwind.Entities.Interfaces
{
    public interface IUnitOfwork
    {

        // forma asincrona
        Task<int> SaveChangesAsync();
    }
}
