using BM.Domain.Books;
using FW.Domain;

namespace BM.Domain.BookCategories
{
    public class BookCategory : BaseEntity<byte>
    {
        public virtual string Name { get;  set; }
        public virtual string Description { get;  set; }
        public virtual string Picture { get;  set; }
        public virtual string PictureAlt { get;  set; }
        public virtual string PictureTitle { get;  set; }
        public virtual string KeyWords { get;  set; }
        public virtual string MetaDescription { get;  set; }
        public virtual string Slug { get;  set; }
        public virtual ICollection<Book> Books { get; set; } 

        public BookCategory()
        {
	       
        }

        public BookCategory( string name, string description, string picture, string pictureAlt, string pictureTitle,
            string keyWords, string metaDescription, string slug)
        {
	        
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }


    }
}
