using Application.Schema.Accounting;
using Domain.Contract.Base;
using Domain.Contract.Schema.Accounting;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Base
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ISessionFactory _sessionFactory;

        private readonly ITransaction _transaction;

        private readonly ISession _session;

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;

            _session = _sessionFactory.OpenSession();

            _transaction = _session.BeginTransaction();
        }

        private IUsersRepository _UsersRepository =null!;
        //private IRoleRepository _roleRepository = null!;
        //private IPersonRepository _personRepository = null!;
        public IUsersRepository UsersRepository
        {
            get
            {
                _UsersRepository ??= new UsersRepository(_session);
                return _UsersRepository;
            }
        }
        //public IPersonRepository PersonRepository
        //{
        //    get
        //    {
        //        _personRepository ??= new PersonRepository(_session);
        //        return _personRepository;
        //    }
        //}

        //public IRoleRepository RoleRepository
        //{
        //    get
        //    {
        //        _roleRepository ??= new RoleRepository(_session);
        //        return _roleRepository;
        //    }
        //}

        public void Commit()
        {
            if (!_transaction.IsActive)
            {
                throw new InvalidOperationException("No active transation");
            }

            _transaction.Commit();
        }

        public void Dispose()
        {
            if (_session.IsOpen)
            {
                _session.Close();
            }
        }

        public void RollBack()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }
    }
}
