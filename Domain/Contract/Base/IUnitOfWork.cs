﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void RollBack();
        //IRoleRepository RoleRepository { get; }
        //IPersonRepository PersonRepository { get; }
    }
}
