using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW.Application;

namespace BM.Application.Contracts.ArticleCategories
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        OperationResult Delete(byte id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
