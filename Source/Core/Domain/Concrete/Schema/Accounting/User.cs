using Domain.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Schema.Accounting
{
    public class User : BaseEntity
    {
        /// <summary>
        /// موجودیت کاربر
        /// </summary>
        public User() 
        { 
           Fullname = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Mobile = string.Empty;
            Email = string.Empty;
            ProfilePhoto = string.Empty;
            CreationDate = DateTime.Now;
            IsDeleted = false;
            Role = null!;
        }
        public virtual int Id { get; set; }
        public virtual string Fullname { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }
        public virtual byte RoleId { get; set; }
        public virtual string ProfilePhoto { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual Role Role { get; set; }
    }
}
