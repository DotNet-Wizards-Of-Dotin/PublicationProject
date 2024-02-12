

using BM.Application.Contracts.BookCategories;
using BM.Domain.BookCategories;
using BM.Domain.UoW;
using FW.Application;

namespace BM.Application.BookCategories
{
    public class BookCategoryApplication : IBookCategoryApplication
    {
	    private readonly IBookCategoryRepository _bookCategoryRepository;
	    private readonly IUnitOfWork _uow;
		private readonly IFileUploader _fileUploader;

	    public BookCategoryApplication(IBookCategoryRepository bookCategoryRepository, IFileUploader fileUploader, IUnitOfWork uow)
	    {
		    _bookCategoryRepository = bookCategoryRepository;
		    _fileUploader = fileUploader;
		    _uow = uow;
	    }

	    public OperationResult Create(CreateBookCategory command)
	    {
			_uow.BeginTransaction();
		    var operationResult = new OperationResult();
		    if (_bookCategoryRepository.Exists(bc => bc.Name == command.Name))
		    {
				_uow.RollBack();
			    return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

			}
				

			var slug = command.Slug.Slugify();
		    var picturePath = $"{command.Slug}";
		    var pictureName = _fileUploader.Upload(command.Picture, picturePath);


			var bookCategory = new BookCategory(command.Name, command.Description, pictureName, command.PictureAlt,
				command.PictureTitle, command.KeyWords, command.MetaDescription, slug);

			_bookCategoryRepository.Create(bookCategory);
			_uow.Commit();
			
			return operationResult.Succeeded();

	    }

	    public OperationResult Edit(EditBookCategory command)
	    {
			_uow.BeginTransaction();
			var operationResult = new OperationResult();

			var bookCategory = _bookCategoryRepository.GetBy(command.Id);
			if (bookCategory == null)
			{
				_uow.RollBack();
				return operationResult.Failed(ApplicationMessages.RecordNotFound);
			}

			if (_bookCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
			{
				_uow.RollBack();
				return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
			}

			var slug = command.Slug.Slugify();
			var picturePath = $"{command.Slug}";
			var pictureName = _fileUploader.Upload(command.Picture, picturePath);

			bookCategory.Picture = string.IsNullOrWhiteSpace(pictureName) ? bookCategory.Picture : pictureName;
			bookCategory.Name = command.Name;
			bookCategory.Description = command.Description;
			bookCategory.PictureAlt = command.PictureAlt;
			bookCategory.PictureTitle = command.PictureTitle;
			bookCategory.KeyWords = command.KeyWords;
			bookCategory.Description = command.Description;
			bookCategory.MetaDescription = command.MetaDescription;
			bookCategory.Slug = slug;

			_bookCategoryRepository.Update(bookCategory);
			_uow.Commit();
			
			
			return operationResult.Succeeded();
	    }

	    public OperationResult Delete(byte id)
	    {
			_uow.BeginTransaction();
			var operationResult = new OperationResult();

			var bookCategory = _bookCategoryRepository.GetBy(id);
			if (bookCategory == null)
			{
				_uow.RollBack();
				return operationResult.Failed(ApplicationMessages.RecordNotFound);
			}

			if (bookCategory.IsDeleted)
			{
				bookCategory.IsDeleted = false;
			}
			else
			{
				bookCategory.IsDeleted = true;
			}
			_bookCategoryRepository.Update(bookCategory);
			_uow.Commit();

			return operationResult.Succeeded();

	    }


	    public List<BookCategoryViewModel> GetBookCategories()
	    {
		    return _bookCategoryRepository.GetBookCategories();
	    }

	    public List<BookCategoryViewModel> Search(BookCategorySearchModel searchModel)
	    {
		    return _bookCategoryRepository.Search(searchModel);
	    }

	    public EditBookCategory GetEditBookCategoryById(byte id)
	    {
		    return _bookCategoryRepository.GetEditBookCategoryById(id);
	    }
    }
}
