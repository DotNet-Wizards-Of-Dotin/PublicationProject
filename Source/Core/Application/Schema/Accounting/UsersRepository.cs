using Application.Base;
using Domain.Concrete.Schema.Accounting;
using Domain.Contract.Schema.Accounting;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Schema.Accounting
{
    public class UsersRepository : BaseRepository<Users> , IUsersRepository
    {
        public UsersRepository(ISession session) : base(session)
        {
        }
    }
}
