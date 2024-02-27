using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Application.Contracts.ArticleCategories;
using FW.Domain;

namespace BM.Domain.ArticleCategories
{
    public interface IArticleCategoryRepository : IBaseRepository<byte,ArticleCategory>
    {
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
