namespace BM.Application.Contracts.Books;

public class BookViewModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Picture { get; set; }

	public string AuthorName { get; set; }
	public byte CategoryId { get; set; }
	public string CreationDate { get; set; }
	public string Category { get; set; }
	public bool IsDeleted { get; set; }

}