using BM.Application.Contracts.Books;
using BM.Domain.BookCategories;
using BM.Domain.Books;
using BM.Domain.UoW;

using FW.Application;

namespace BM.Application.Books
{
	public class BookApplication : IBookApplication
	{
		private readonly IBookRepository _bookRepository;
		private readonly IBookCategoryRepository _bookCategoryRepository;
		private readonly IUnitOfWork _uow;
		private readonly IFileUploader _fileUploader;

		public BookApplication(IBookRepository bookRepository, IUnitOfWork uow, IFileUploader fileUploader, IBookCategoryRepository bookCategoryRepository)
		{
			_bookRepository = bookRepository;
			_uow = uow;
			_fileUploader = fileUploader;
			_bookCategoryRepository = bookCategoryRepository;
		}
		public OperationResult Create(CreateBook command)
		{
			_uow.BeginTransaction();
			var operationResult = new OperationResult();
			if (_bookRepository.Exists(b => b.Name == command.Name))
			{
				_uow.RollBack();
				return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

			}

			var slug = command.Slug.Slugify();
			var categorySlug = _bookCategoryRepository.GetBookCategorySlugById(command.CategoryId);
			var path = $"{categorySlug}/{slug}";
			var picturePath = _fileUploader.Upload(command.Picture, path);

			

			var book = new Book(command.Name, command.AuthorName, command.ShortDescription,
				command.Description, picturePath, command.PictureAlt, command.PictureTitle, slug,
				command.KeyWords, command.MetaDescription, command.CategoryId);

			var bookCategory = _bookCategoryRepository.GetBy(book.BookCategoryId);

			book.BookCategory = bookCategory;

			_bookRepository.Create(book);
			_uow.Commit();

			return operationResult.Succeeded();

		}

		public OperationResult Edit(EditBook command)
		{
			_uow.BeginTransaction();
			var operationResult = new OperationResult();

			var book = _bookRepository.GetBy(command.Id);

			if (book == null)
			{
				_uow.RollBack();
				return operationResult.Failed(ApplicationMessages.RecordNotFound);
			}

			if (_bookRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
			{
				_uow.RollBack();
				return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

			}

			var slug = command.Slug.Slugify();
			var categorySlug = _bookCategoryRepository.GetBookCategorySlugById(command.CategoryId);
			var path = $"{categorySlug}/{slug}";
			var picturePath = _fileUploader.Upload(command.Picture, path);

			if (command.CategoryId != null && command.CategoryId != book.BookCategoryId)
			{
				book.BookCategory = _bookCategoryRepository.GetBy(command.CategoryId);
				book.BookCategoryId = command.CategoryId;
			}
				

			book.Picture = string.IsNullOrWhiteSpace(picturePath) ? book.Picture : picturePath;
			book.Name = command.Name;
			book.AuthorName = command.AuthorName;
			book.ShortDescription = command.ShortDescription;
			book.Slug = command.Slug;
			book.PictureTitle = command.PictureTitle;
			book.KeyWords = command.KeyWords;
			book.PictureAlt = command.PictureAlt;
			book.Description = command.Description;
			book.MetaDescription = command.MetaDescription;

			_bookRepository.Create(book);
			_uow.Commit();
			return operationResult.Succeeded();
		}

		public OperationResult Delete(int id)
		{
			_uow.BeginTransaction();
			var operationResult = new OperationResult();

			var book = _bookRepository.GetBy(id);

			if (book == null)
			{
				_uow.RollBack();
				return operationResult.Failed(ApplicationMessages.RecordNotFound);
			}

			if (book.IsDeleted)
			{
				book.IsDeleted = false;
			}
			else
			{
				book.IsDeleted = true;
			}
			_bookRepository.Update(book);
			_uow.Commit();

			return operationResult.Succeeded();
		}

		public EditBook GetDetails(int id)
		{
			return _bookRepository.GetDetails(id);
		}

		public List<BookViewModel> Search(BookSearchModel searchModel)
		{
			return _bookRepository.Search(searchModel);
		}

		public List<BookViewModel> GetBooks()
		{
			return _bookRepository.GetBooks();
		}
	}
}
