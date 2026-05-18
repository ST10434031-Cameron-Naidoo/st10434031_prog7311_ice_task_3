using Microsoft.AspNetCore.Mvc;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;

namespace Primary_And_High_School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public StudentsController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentRepo.GetAllStudents());
        }

        [HttpGet("{studentNumber}")]
        public IActionResult GetByNumber(string studentNumber)
        {
            var student = _studentRepo.GetStudentByNumber(studentNumber);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _studentRepo.AddStudent(student);
            return CreatedAtAction(nameof(GetByNumber),
                new { studentNumber = student.StudentNumber }, student);
        }

        [HttpPut("{studentNumber}")]
        public IActionResult Update(string studentNumber, Student student)
        {
            if (studentNumber != student.StudentNumber) return BadRequest();
            _studentRepo.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{studentNumber}")]
        public IActionResult Delete(string studentNumber)
        {
            var student = _studentRepo.GetStudentByNumber(studentNumber);
            if (student == null) return NotFound();
            _studentRepo.DeleteStudent(studentNumber);
            return NoContent();
        }
    }
}