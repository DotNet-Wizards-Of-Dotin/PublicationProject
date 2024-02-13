using FW.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.Users
{
    public interface IUserApplication
    {
        OperationResult Create(CreateUser command);
        OperationResult Edit(EditUser command);
        OperationResult Delete(int id);
        EditUser GetDetails(int id);
        List<UserViewModel> Search(UserSearchModel searchModel);
        List<UserViewModel> GetUsers();
    }
}
