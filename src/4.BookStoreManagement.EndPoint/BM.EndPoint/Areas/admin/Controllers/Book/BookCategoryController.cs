using BM.Application.Contracts.BookCategories;
using Microsoft.AspNetCore.Mvc;

namespace BM.EndPoint.Areas.admin.Controllers.Book
{
	[Area("admin")]
	public class BookCategoryController : Controller
	{
		private readonly IBookCategoryApplication _bookCategoryApplication;

		public BookCategoryController(IBookCategoryApplication bookCategoryApplication)
		{
			_bookCategoryApplication = bookCategoryApplication;
		}

		[Route("admin/bookcategories")]
		public IActionResult Index(string searchModel)
		{
			var search = new BookCategorySearchModel() { Name = searchModel };
			var bookCategory = _bookCategoryApplication.Search(search);
			return View(bookCategory);

		}


		[Route("admin/bookcategory/create")]
		[HttpGet]
		public IActionResult Create()
		{
			return PartialView("_Create", new CreateBookCategory());
		}


		[Route("admin/bookcategory/create")]
		[HttpPost]
		public JsonResult Create(CreateBookCategory commend)
		{
			var result = _bookCategoryApplication.Create(commend);

			return new JsonResult(result);
		}

		[Route("admin/bookcategory/Edit")]
		[HttpGet]
		public IActionResult Edit(byte id)
		{
			var commend = _bookCategoryApplication.GetEditBookCategoryById(id);

			return PartialView("_Edit", commend);
		}
		[Route("admin/bookcategory/Edit")]
		[HttpPost]
		public IActionResult Edit(EditBookCategory command)
		{
			var result = _bookCategoryApplication.Edit(command);

			return Json(result);
		}
		[Route("admin/bookcategory/Delete")]
		public IActionResult Delete(byte id)
		{
			var result = _bookCategoryApplication.Delete(id);
			return RedirectToAction("Index");
		}

	}
}
