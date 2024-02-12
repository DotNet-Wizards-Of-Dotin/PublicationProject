using BM.Domain.UoW;
using FW.Infrastructure;
using NHibernate;

namespace BM.Infrastructure.UoW
{
	public class UnitOfWork : BaseUnitOfWork , IUnitOfWork
	{
		public UnitOfWork(ISession session) : base(session)
		{
		}
	}
}
