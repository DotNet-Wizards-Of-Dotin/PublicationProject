using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.Users
{
    public class UserViewModel
    {
        public Int32 Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public byte RoleId { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime CreationDate { get; set; }
        public Boolean IsDeleted { get; set; }
        
    }
}
