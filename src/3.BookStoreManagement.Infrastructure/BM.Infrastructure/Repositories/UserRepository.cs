using BM.Application.Contracts.Users;
using BM.Domain.Users;
using FW.Application;
using FW.Infrastructure;
using NHibernate;

namespace BM.Infrastructure.Repositories
{
    public class UserRepository: BaseRepository<int,User> , IUserRepository
    {
        private readonly ISession _session;

        public UserRepository(ISession session) : base(session)
        {
            _session=session;
        }
        public List<UserViewModel> Search(UserSearchModel searchModel)
        {
            var query = _session.Query<User>().ToList();
            if(!string.IsNullOrWhiteSpace(searchModel.Fullname))
            {
                query = query.Where(u => u.Fullname.Contains(searchModel.Fullname)).ToList();
            }
            
            if (!string.IsNullOrWhiteSpace(searchModel.Username))
            {
                query = query.Where(u => u.Username.Contains(searchModel.Username)).ToList();
            }
           
            if(searchModel.RoleId != 0)
            {
                query = query.Where(u => u.Role.Id == searchModel.RoleId).ToList();
            }

            return query.Select( u => new UserViewModel()
            {
                Fullname = u.Fullname,
                Username = u.Username,
                Password = u.Password,
                IsDeleted = u.IsDeleted,
                RoleId = u.RoleId,
                ProfilePhoto = u.ProfilePhoto,
                Role = u.Role.Name,
                Email = u.Email,
                CreationDate = u.CreationDate,
                Mobile = u.Mobile
            }).ToList();
        }

        public EditUser GetDetails(int id) 
        {
            var user = _session.Get<User>(id);
            return new EditUser()
            {
                Id= user.Id,
                Fullname = user.Fullname,
                Username = user.Username,
                Password = user.Password,
                IsDeleted = user.IsDeleted,
                RoleId = user.RoleId,
                Email = user.Email,
                CreationDate= user.CreationDate,
                Mobile = user.Mobile
            };
        }

        public List<UserViewModel> GetUsers()
        {
            var users = _session.Query<User>().ToList();
            return users.Select(u => new UserViewModel()
            {
                Id = u.Id,
                Fullname = u.Fullname,
                Username = u.Username,
                Password = u.Password,
                IsDeleted = u.IsDeleted,
                RoleId = u.RoleId,
                Email = u.Email,
                CreationDate = u.CreationDate.ToFarsi(),
                ProfilePhoto = u.ProfilePhoto,
                Role = u.Role.Name,
                Mobile = u.Mobile
               
            }).ToList();
        }

        public UserSearchModel get
    }
}
