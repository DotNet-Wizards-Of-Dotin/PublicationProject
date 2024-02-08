using Domain.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Schema.Accounting
{
    public class Users : BaseEntity
    {
        /// <summary>
        /// موجودیت کاربر
        /// </summary>
        /// 
        public Users() 
        {
            Fullname = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Mobile = string.Empty;
            Email = string.Empty;
            ProfilePhoto = string.Empty;
            Role = null!;
        }
        //    public Users(string fullname, string username, 
        //                 string password, string mobile, string email,
        //                 byte roleId, string profilePhoto, DateTime creationDate,
        //                 Boolean isDeleted) 
        //{ 
        //    //Role = new Role();
        //    Fullname = fullname;
        //    Username = username;
        //    Password = password;
        //    Mobile = mobile;
        //    Email = email;
        //    RoleId = roleId;
        //    ProfilePhoto = profilePhoto;
        //    CreationDate = creationDate;
        //    IsDeleted = isDeleted;
        //    //CreationDate = DateTime.Now;
        //    //IsDeleted = false;
        //    Role = null!;
        //}
        public virtual Int32 Id { get; set; }
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

        public override string ToString()
        {
            return $"{Id} {Fullname} {Username} {Password} {CreationDate} {IsDeleted} {RoleId}";
        }

    }
}
