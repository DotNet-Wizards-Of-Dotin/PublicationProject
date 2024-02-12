using BM.Application.Contracts.Books;
using BM.Domain.Books;
using FW.Application;
using FW.Infrastructure;
using NHibernate;

namespace BM.Infrastructure.Repositories
{
	public class BookRepository :BaseRepository<int,Book>, IBookRepository
	{
		private readonly ISession _session;
		public BookRepository(ISession session) : base(session)
		{
			_session = session;
		}

		public List<BookViewModel> Search(BookSearchModel searchModel)
		{
			var query = _session.Query<Book>().ToList();
			if (!string.IsNullOrWhiteSpace(searchModel.Name))
			{
				query = query.Where(b => b.Name.Contains(searchModel.Name)).ToList();
			}
			if (!string.IsNullOrWhiteSpace(searchModel.AuthorName))
			{
				query = query.Where(b => b.AuthorName.Contains(searchModel.AuthorName)).ToList();
			}

			if (searchModel.CategoryId != 0)
			{
				query = query.Where(b => b.BookCategory.Id == searchModel.CategoryId).ToList();
			}

			return query.Select(b => new BookViewModel()
			{
				Name = b.Name,
				IsDeleted = b.IsDeleted,
				Category = b.BookCategory.Name,
				CategoryId = b.BookCategoryId,
				AuthorName = b.AuthorName,
				CreationDate = b.CreationDate.ToFarsi(),
				Id = b.Id,
				Picture = b.Picture

			}).ToList();
		}

		public EditBook GetDetails(int id)
		{
			var book = _session.Get<Book>(id);
			return new EditBook()
			{
				Id = book.Id,
				CategoryId = book.BookCategoryId,
				Description = book.Description,
				KeyWords = book.KeyWords,
				Name = book.Name,
				MetaDescription = book.MetaDescription,
				Slug = book.Slug,
				AuthorName = book.AuthorName,
				PictureAlt = book.PictureAlt,
				PictureTitle = book.PictureTitle,
				ShortDescription = book.ShortDescription,
				

			};
		}

		public List<BookViewModel> GetBooks()
		{
			var books = _session.Query<Book>().ToList();
			return books.Select(b => new BookViewModel()
			{
				Name = b.Name,
				IsDeleted = b.IsDeleted,
				Category = b.BookCategory.Name,
				CategoryId = b.BookCategoryId,
				AuthorName = b.AuthorName,
				CreationDate = b.CreationDate.ToFarsi(),
				Id = b.Id,
				Picture = b.Picture

			}).ToList();
		}

		public BookViewModel GetBookWithCategory(int id)
		{
			var book = _session.Get<Book>(id);
			return new BookViewModel()
			{
				Name = book.Name,
				IsDeleted = book.IsDeleted,
				Category = book.BookCategory.Name,
				CategoryId = book.BookCategoryId,
				AuthorName = book.AuthorName,
				CreationDate = book.CreationDate.ToFarsi(),
				Id = book.Id,
				Picture = book.Picture,
			};
		}

		
	}
}
