namespace FW.Domain
{
	public interface IBaseUnitOfWork : IDisposable
	{
		void Commit();
		void RollBack();
		void BeginTransaction();

	}
}
