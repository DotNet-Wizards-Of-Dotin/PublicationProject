using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.ArticleCategories
{
    public class EditArticleCategory : CreateArticleCategory
    {
        public byte Id { get; set; }
    }
}
