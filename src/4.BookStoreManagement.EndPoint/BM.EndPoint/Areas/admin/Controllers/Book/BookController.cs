using BM.Application.Contracts.BookCategories;
using BM.Application.Contracts.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BM.EndPoint.Areas.admin.Controllers.Book
{
	[Area("admin")]
	public class BookController : Controller
	{
		private readonly IBookApplication _bookApplication;
		private readonly IBookCategoryApplication _bookCategoryApplication;

		public BookController(IBookCategoryApplication bookCategoryApplication, IBookApplication bookApplication)
		{
			_bookCategoryApplication = bookCategoryApplication;
			_bookApplication = bookApplication;
		}

		[Route("admin/books")]
		public IActionResult Index(string name,string authorName, byte categoryId)
		{
			var bookCategories = new SelectList(_bookCategoryApplication.GetBookCategories(), "Id", "Name");
			ViewBag.BookCategories = bookCategories;

			var serachModel = new BookSearchModel() { Name = name,AuthorName = authorName, CategoryId = categoryId };

			var books = _bookApplication.Search(serachModel);

			return View(books);
		}

		[Route("admin/book/create")]
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.BookCategories = _bookCategoryApplication.GetBookCategories();
			return PartialView("_Create", new CreateBook());
		}


		[Route("admin/book/create")]
		[HttpPost]
		public JsonResult Create(CreateBook commend)
		{
			var result = _bookApplication.Create(commend);

			return new JsonResult(result);
		}

		[Route("admin/book/Edit")]
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var commend = _bookApplication.GetDetails(id);
			commend.BookCategories = _bookCategoryApplication.GetBookCategories();

			return PartialView("_Edit", commend);
		}
		[Route("admin/book/Edit")]
		[HttpPost]
		public IActionResult Edit(EditBook command)
		{
			var result = _bookApplication.Edit(command);

			return Json(result);
		}
		[Route("admin/book/Delete")]
		public IActionResult Delete(int id)
		{
			var result = _bookApplication.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
