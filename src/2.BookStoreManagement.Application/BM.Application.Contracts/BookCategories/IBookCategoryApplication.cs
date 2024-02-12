using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW.Application;


namespace BM.Application.Contracts.BookCategories
{
	public interface IBookCategoryApplication
	{
		OperationResult Create(CreateBookCategory command);
		OperationResult Edit(EditBookCategory command);
		OperationResult Delete(byte id);
		List<BookCategoryViewModel> GetBookCategories();
		List<BookCategoryViewModel> Search(BookCategorySearchModel searchModel);
		EditBookCategory GetEditBookCategoryById(byte id);

	}
}
