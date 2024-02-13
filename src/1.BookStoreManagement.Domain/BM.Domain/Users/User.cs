using BM.Domain.BookCategories;
using FW.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BM.Domain.Users
{
    public class User :BaseEntity
    {
        public virtual string Fullname { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }
        public virtual byte RoleId { get; set; }
        public virtual string ProfilePhoto { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual Boolean IsDeleted { get; set; }
        public virtual Role Role { get; set; }



        public User()
        {
            //BookCategory = new BookCategory();

        }

        public User(string fullname, string username, string password, string mobile, string email,
            byte roleid, string profilephoto, DateTime creationdate)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            Email = email;
            RoleId = roleid;
            ProfilePhoto = profilephoto;
            CreationDate = creationdate;
        }
    }
}
