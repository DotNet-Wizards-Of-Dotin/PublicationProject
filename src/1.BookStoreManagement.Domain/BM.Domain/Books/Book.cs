using BM.Domain.BookCategories;
using FW.Domain;

namespace BM.Domain.Books
{
	public class Book : BaseEntity
	{
		public virtual string Name { get;  set; }
		public virtual string AuthorName { get;  set; }
		public virtual string ShortDescription { get;  set; }
		public virtual string Description { get;  set; }
		public virtual string Picture { get;  set; }
		public virtual string PictureAlt { get;  set; }
		public virtual string PictureTitle { get;  set; }
		public virtual string Slug { get;  set; }
		public virtual string KeyWords { get;  set; }
		public virtual string MetaDescription { get;  set; }
		public virtual byte BookCategoryId { get;  set; }
		public virtual BookCategory BookCategory { get; set; }
		

		public Book()
		{
			BookCategory = new BookCategory();

		}

		public Book( string name, string authorName, string shortDescription, string description, string picture,
			string pictureAlt, string pictureTitle, string slug, string keyWords, string metaDescription,
			byte bookCategoryId)
		{
			Name = name;
			AuthorName = authorName;
			ShortDescription = shortDescription;
			Description = description;
			Picture = picture;
			PictureAlt = pictureAlt;
			PictureTitle = pictureTitle;
			Slug = slug;
			KeyWords = keyWords;
			MetaDescription = metaDescription;
			BookCategoryId = bookCategoryId;
		}

	}

}
