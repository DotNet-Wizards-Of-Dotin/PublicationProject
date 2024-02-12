using BM.Application.BookCategories;
using BM.Application.Books;
using BM.Application.Contracts.BookCategories;
using BM.Application.Contracts.Books;
using BM.Domain.BookCategories;
using BM.Domain.Books;
using BM.Domain.UoW;
using BM.Infrastructure.Repositories;
using BM.Infrastructure.UoW;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;

namespace BM.Infrastructure.Config
{
	public static class BookStoreManagementBootstrapper
	{
		public static IServiceCollection AddConfiguration(this IServiceCollection services, string connectionString)
		{
			var configuration = new Configuration();

			configuration.AddAssembly("BM.Infrastructure");

			configuration.DataBaseIntegration(c =>
			{
				c.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
				c.ConnectionString = connectionString;
				c.LogFormattedSql = true;
				c.LogSqlInConsole = true;
			});
			
			var sessionFactory = configuration.BuildSessionFactory();
			services.AddScoped(factory => sessionFactory.OpenSession());
			services.AddSingleton(sessionFactory);


			services.AddScoped(factory => sessionFactory.OpenSession());
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IBookCategoryApplication, BookCategoryApplication>();
			services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();


			services.AddScoped<IBookApplication, BookApplication>();
			services.AddScoped<IBookRepository, BookRepository>();
			


			return services;
		}
	}
}
