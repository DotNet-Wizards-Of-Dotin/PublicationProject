using BM.Application.Contracts.BookCategories;

namespace BM.Application.Contracts.Books;

public class EditBook : CreateBook
{
    public int Id { get; set; }
    public List<BookCategoryViewModel> BookCategories { get; set; }
    
}