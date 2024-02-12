using BM.Application.Contracts.BookCategories;
using FW.Domain;

namespace BM.Domain.BookCategories
{
	public interface IBookCategoryRepository : IBaseRepository<byte,BookCategory>
	{
		
		List<BookCategoryViewModel> GetBookCategories();
		
		EditBookCategory GetEditBookCategoryById(byte id);
		List<BookCategoryViewModel> Search(BookCategorySearchModel searchModel);
		string GetBookCategorySlugById(byte id);

	}
}
