using Microsoft.AspNetCore.Mvc;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;

namespace Primary_And_High_School.MVC.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepo;
        private readonly IStudentRepository _studentRepo;

        public SubjectController(ISubjectRepository subjectRepo, IStudentRepository studentRepo)
        {
            _subjectRepo = subjectRepo;
            _studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            var subjects = _subjectRepo.GetAllSubjects();
            return View(subjects);
        }

        public IActionResult Create()
        {
            ViewBag.Students = _studentRepo.GetAllStudents();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectRepo.AddSubject(subject);
                return RedirectToAction("Index");
            }
            ViewBag.Students = _studentRepo.GetAllStudents();
            return View(subject);
        }

        public IActionResult Edit(int id)
        {
            var subject = _subjectRepo.GetSubjectById(id);
            if (subject == null) return NotFound();
            ViewBag.Students = _studentRepo.GetAllStudents();
            return View(subject);
        }

        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectRepo.UpdateSubject(subject);
                return RedirectToAction("Index");
            }
            ViewBag.Students = _studentRepo.GetAllStudents();
            return View(subject);
        }

        public IActionResult Delete(int id)
        {
            var subject = _subjectRepo.GetSubjectById(id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _subjectRepo.DeleteSubject(id);
            return RedirectToAction("Index");
        }
    }
}