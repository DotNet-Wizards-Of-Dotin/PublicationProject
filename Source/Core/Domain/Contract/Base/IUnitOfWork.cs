using Domain.Contract.Schema.Accounting;
using System;
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
        IUsersRepository UsersRepository { get; }
       
    }
}
