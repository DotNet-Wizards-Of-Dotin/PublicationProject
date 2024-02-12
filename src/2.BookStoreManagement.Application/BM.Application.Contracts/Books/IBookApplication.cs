using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW.Application;

namespace BM.Application.Contracts.Books
{
	public interface IBookApplication
	{
		OperationResult Create(CreateBook command);
		OperationResult Edit(EditBook command);
		OperationResult Delete(int id);
		EditBook GetDetails(int id);
		List<BookViewModel> Search(BookSearchModel searchModel);
		List<BookViewModel> GetBooks();
	}
}
