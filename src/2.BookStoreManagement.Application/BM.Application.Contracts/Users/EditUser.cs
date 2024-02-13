using BM.Application.Contracts.BookCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.Users
{
    public class EditUser : CreateUser
    {
        public int Id { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
