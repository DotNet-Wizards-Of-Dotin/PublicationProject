using Domain.Concrete.Schema.Accounting;
using Domain.Contract.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PublicationProject.Controllers
{
    public class UsersController (IUnitOfWork unitOfWork): Controller
    {
       private readonly IUnitOfWork _unitOfWork = unitOfWork;
        
       public JsonResult Index()
        {
            var Users = _unitOfWork.UsersRepository.GetAll();
            return Json(Users);
        }
        
        public JsonResult Get(int id) 
        {
            var Users = _unitOfWork.UsersRepository.Get(id);
            return Json(Users);
        }
        
        public IActionResult Create()
        {
            var Users1 = new Users
            {
                Fullname = "Test",
                Username = "Test",
                Password = "Test",
                Mobile = "022555",
                Email = "Test",
                RoleId = 1,
                ProfilePhoto = "S:\\Dotin Bootcamp\\Final Project\\Diagram",
                CreationDate = DateTime.Now,
                IsDeleted = false,
                
            };

            _unitOfWork.UsersRepository.Insert(Users1);

            _unitOfWork.Commit();
            return Ok();
        }
    }
}
