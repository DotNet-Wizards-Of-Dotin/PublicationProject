using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Application.Contracts.ArticleCategories;
using BM.Domain.ArticleCategories;
using FW.Application;
using FW.Infrastructure;
using NHibernate;

namespace BM.Infrastructure.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<byte,ArticleCategory>, IArticleCategoryRepository
    {
        private ISession _session;
        public ArticleCategoryRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _session.Query<ArticleCategory>();
            

            if (searchModel.Name != null)
            {
                query = query.Where(q => q.Name.Contains(searchModel.Name));
            }

            return query.Select(q => new ArticleCategoryViewModel()
            {
                Name = q.Name,
                CreationDate = q.CreationDate.ToFarsi(),
                Description = q.Description,
                Id = q.Id,
                Picture = q.Picture

            }).ToList();

            
        }
    }
}
