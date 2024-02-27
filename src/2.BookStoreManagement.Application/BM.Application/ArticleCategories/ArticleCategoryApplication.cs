using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Application.Contracts.ArticleCategories;
using BM.Domain.ArticleCategories;
using FW.Application;

namespace BM.Application.ArticleCategories
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(byte id)
        {
            throw new NotImplementedException();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }
    }
}
