using System.Linq.Expressions;

namespace FW.Domain
{
	public interface IBaseRepository<TKey, T>  where T : class
	{

		T GetBy(TKey id);
		List<T> GetAll();
		bool Exists(Expression<Func<T, bool>> exception);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
		
	}
}
