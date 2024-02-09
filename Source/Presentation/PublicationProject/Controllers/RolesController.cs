using Application.Base;
using Domain.Concrete.Schema.Accounting;
using Domain.Contract.Base;
using Microsoft.AspNetCore.Mvc;

namespace PublicationProject.Controllers
{
    public class RolesController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public JsonResult Index()
        {
            var Roles = _unitOfWork.UsersRepository.GetAll();
            return Json(Roles);
        }

        public JsonResult Get(int id)
        {
            var Roles = _unitOfWork.UsersRepository.Get(id);
            return Json(Roles);
        }

        public IActionResult Create()
        {
            var Roles1 = new Roles
            {
                Name = "Name",
                CreationDate = DateTime.Now,
                IsDeleted = false,

            };

            _unitOfWork.RolesRepository.Insert(Roles1);

            _unitOfWork.Commit();
            return Ok();
        }
    }
}
