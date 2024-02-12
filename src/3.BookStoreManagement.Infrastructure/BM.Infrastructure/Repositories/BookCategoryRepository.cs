using BM.Application.Contracts.BookCategories;
using BM.Domain.BookCategories;
using FW.Application;
using FW.Infrastructure;
using NHibernate;

namespace BM.Infrastructure.Repositories
{
	public class BookCategoryRepository : BaseRepository<byte,BookCategory>, IBookCategoryRepository
	{
		private readonly ISession _session;
		
		public BookCategoryRepository(ISession session) : base(session)
		{
			_session = session;
			
		}

		public List<BookCategoryViewModel> GetBookCategories()
		{
			var x = _session.Query<BookCategory>().ToList();
			return _session.Query<BookCategory>()
				.Select(bc => new BookCategoryViewModel
				{
					Id = bc.Id,
					Name = bc.Name,
					CreationDate = bc.CreationDate.ToFarsi(),
					Picture = bc.Picture,

				}).ToList();
		}

		public EditBookCategory GetEditBookCategoryById(byte id)
		{
			var bookCategory = _session.Get<BookCategory>(id);
			return new EditBookCategory()
			{
				Description = bookCategory.Description,
				Id = bookCategory.Id,
				KeyWords = bookCategory.KeyWords,
				MetaDescription = bookCategory.MetaDescription,
				Name = bookCategory.Name,
				PictureAlt = bookCategory.PictureAlt,
				PictureTitle = bookCategory.PictureTitle,
				Slug = bookCategory.Slug

			};
		}

		public List<BookCategoryViewModel> Search(BookCategorySearchModel searchModel)
		{
			var query = _session.Query<BookCategory>().ToList();
			if (!string.IsNullOrWhiteSpace(searchModel.Name))
			{
				query = query.Where(q => q.Name.Contains(searchModel.Name)).ToList();
			}

			return query.Select(q => new BookCategoryViewModel()
			{
				Name = q.Name,
				Picture = q.Picture,
				Id = q.Id,
				CreationDate = q.CreationDate.ToFarsi(),
				IsDeleted = q.IsDeleted
			}).ToList();
		}

		public string GetBookCategorySlugById(byte id)
		{
			return _session.Get<BookCategory>(id).Slug;
		}
	}
}
