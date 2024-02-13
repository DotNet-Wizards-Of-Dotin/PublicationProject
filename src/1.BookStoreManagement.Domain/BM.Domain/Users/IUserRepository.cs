using BM.Application.Contracts.Users;
using BM.Application.Contracts.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Domain.Books;
using FW.Domain;

namespace BM.Domain.Users
{
    public interface IUserRepository : IBaseRepository<int, User>
    {
        List<UserViewModel> Search(UserSearchModel searchModel);

        EditUser GetDetails(int id);

        List<UserViewModel> GetUsers();
        public UserViewModel GetUserWithRole(int id);
    }
}
