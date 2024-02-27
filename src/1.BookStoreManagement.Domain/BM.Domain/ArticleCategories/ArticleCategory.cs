using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW.Domain;

namespace BM.Domain.ArticleCategories
{
    public class ArticleCategory : BaseEntity<byte>
    {
        public virtual string Name { get;  set; }
        public virtual string Picture { get;  set; }
        public virtual string PictureAlt { get;  set; }
        public virtual string PictureTitle { get;  set; }
        public virtual string Description { get;  set; }
        public virtual string Slug { get;  set; }
        public virtual string Keywords { get;  set; }
        public virtual string MetaDescription { get;  set; }
        
        //public List<Article> Articles { get;  set; }

        public ArticleCategory(string name, string picture, string pictureAlt, string pictureTitle,
            string description, string slug, string keywords, string metaDescription
            )
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }
    }
}
