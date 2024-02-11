using FW.Domain;
using NHibernate;

namespace FW.Infrastructure
{
	public class BaseUnitOfWork : IBaseUnitOfWork
	{
		private readonly ISession _session;
		private  ITransaction _transaction;

		public BaseUnitOfWork(ISession session)
		{
			_session = session;
		}
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

		public void BeginTransaction()
		{
			_transaction = _session.BeginTransaction();
		}
	}
}
