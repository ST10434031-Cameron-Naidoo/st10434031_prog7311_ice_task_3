using Microsoft.AspNetCore.Mvc;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;

namespace Primary_And_High_School.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            var students = _studentRepo.GetAllStudents();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(string id)
        {
            var student = _studentRepo.GetStudentByNumber(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(string id)
        {
            var student = _studentRepo.GetStudentByNumber(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            _studentRepo.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}