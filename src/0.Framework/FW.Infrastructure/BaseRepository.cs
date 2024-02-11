using System.Linq.Expressions;
using FW.Domain;
using NHibernate;

namespace FW.Infrastructure
{
	public class BaseRepository<TKey, T> : IBaseRepository<TKey, T> where T : class
	{
		private readonly ISession _session;
		

		public BaseRepository(ISession session)
		{
			_session = session;
			
		}

		public T GetBy(TKey id)
		{
			return _session.Get<T>(id);
		}

		public List<T> GetAll()
		{
			return _session.Query<T>().ToList();
		}

		public bool Exists(Expression<Func<T, bool>> exception)
		{
			return _session.Query<T>().Any(exception);
		}

		public void Create(T entity)
		{
			_session.Save(entity);
			
		}

		public void Update(T entity)
		{
			_session.SaveOrUpdate(entity);
			
		}

		public void Delete(T entity)
		{
			_session.Delete(entity);
		}


		public TKey GetNextValue(Expression<Func<T, TKey>> exception)
		{
			return _session.Query<T>().Max(exception);
		}

		

		
	}
}
