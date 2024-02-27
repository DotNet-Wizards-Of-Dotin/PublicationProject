using FW.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.ArticleCategories
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Name { get; set; }

        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string MetaDescription { get; set; }

    }
}
