using Microsoft.AspNetCore.Mvc;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;

namespace Primary_And_High_School.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;
        private readonly ISubjectRepository _subjectRepo;

        public BookController(IBookRepository bookRepo, ISubjectRepository subjectRepo)
        {
            _bookRepo = bookRepo;
            _subjectRepo = subjectRepo;
        }

        public IActionResult Index()
        {
            var books = _bookRepo.GetAllBooks();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Subjects = _subjectRepo.GetAllSubjects();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.AddBook(book);
                return RedirectToAction("Index");
            }
            ViewBag.Subjects = _subjectRepo.GetAllSubjects();
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book == null) return NotFound();
            ViewBag.Subjects = _subjectRepo.GetAllSubjects();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.UpdateBook(book);
                return RedirectToAction("Index");
            }
            ViewBag.Subjects = _subjectRepo.GetAllSubjects();
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookRepo.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}