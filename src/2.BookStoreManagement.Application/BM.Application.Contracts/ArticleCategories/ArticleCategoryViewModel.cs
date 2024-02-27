using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.ArticleCategories
{
    public class ArticleCategoryViewModel
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
        public int ArticlesCount { get; set; }
    }
}
