using System.ComponentModel.DataAnnotations;
using FW.Application;
using Microsoft.AspNetCore.Http;



namespace BM.Application.Contracts.Books
{
	public class CreateBook
	{
		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string Name { get; set; }
		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string AuthorName { get; set; }
		public string? ShortDescription { get; set; }
		public string? Description { get; set; }
		[FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InValidFileFormat)]
		[MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
		public IFormFile? Picture { get; set; }
		public string? PictureAlt { get; set; }
		public string? PictureTitle { get; set; }
		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string Slug { get; set; }

		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string KeyWords { get; set; }

		[Required(ErrorMessage = ValidationMessages.IsRequierd)]
		public string MetaDescription { get; set; }

		[Range(1, 256, ErrorMessage = ValidationMessages.IsRequierd)]
		public byte CategoryId { get; set; }

		
	}


}
