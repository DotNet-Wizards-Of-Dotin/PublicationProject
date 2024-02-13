using FW.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.Users
{
    public class CreateUser
    {
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Fullname { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Username { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Password { get; set; }
       
        [Required(ErrorMessage = ValidationMessages.IsRequierd)]
        public string Mobile { get; set; }
        
        public string? Email { get; set; }

        [Range(1, 256, ErrorMessage = ValidationMessages.IsRequierd)]
        public byte RoleId { get; set; }

        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InValidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile? ProfilePhoto { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
        public Boolean? IsDeleted { get; set; }

    }
}
