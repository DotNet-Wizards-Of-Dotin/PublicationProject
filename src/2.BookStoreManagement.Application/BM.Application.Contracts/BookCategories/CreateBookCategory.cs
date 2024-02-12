using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using FW.Application;


namespace BM.Application.Contracts.BookCategories
{
	public class CreateBookCategory
	{
		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string Name { get; set; }
		public string? Description { get; set; }
		[FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InValidFileFormat)]
		[MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
		public IFormFile? Picture { get; set; }
		public string? PictureAlt { get; set; }
		public string? PictureTitle { get; set; }

		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string KeyWords { get; set; }

		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string MetaDescription { get; set; }

		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string Slug { get; set; }
	}
}
