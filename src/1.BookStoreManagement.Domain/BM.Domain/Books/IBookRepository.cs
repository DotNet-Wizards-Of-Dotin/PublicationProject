using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Application.Contracts.Books;
using FW.Domain;

namespace BM.Domain.Books
{
	public interface IBookRepository : IBaseRepository<int, Book>
	{
		List<BookViewModel> Search(BookSearchModel searchModel);


		EditBook GetDetails(int id);

		List<BookViewModel> GetBooks();
		public BookViewModel GetBookWithCategory(int id);

		
	}
}
