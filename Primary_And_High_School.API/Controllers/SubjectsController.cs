using Microsoft.AspNetCore.Mvc;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;

namespace Primary_And_High_School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepo;

        public SubjectsController(ISubjectRepository subjectRepo)
        {
            _subjectRepo = subjectRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_subjectRepo.GetAllSubjects());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subject = _subjectRepo.GetSubjectById(id);
            if (subject == null) return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            _subjectRepo.AddSubject(subject);
            return CreatedAtAction(nameof(GetById),
                new { id = subject.SubjectId }, subject);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Subject subject)
        {
            if (id != subject.SubjectId) return BadRequest();
            _subjectRepo.UpdateSubject(subject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var subject = _subjectRepo.GetSubjectById(id);
            if (subject == null) return NotFound();
            _subjectRepo.DeleteSubject(id);
            return NoContent();
        }
    }
}