using Microsoft.EntityFrameworkCore;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;
using Primary_High_School.DAL;

namespace Primary_And_High_School.Services.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly Primary_And_HighDbContext _context;

        public SubjectRepository(Primary_And_HighDbContext context)
        {
            _context = context;
        }

        public List<Subject> GetAllSubjects()
        {
            return _context.Subjects
                .Include(s => s.Books)
                .Include(s => s.Student)
                .ToList();
        }

        public Subject? GetSubjectById(int id)
        {
            return _context.Subjects
                .Include(s => s.Books)
                .Include(s => s.Student)
                .FirstOrDefault(s => s.SubjectId == id);
        }

        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public void DeleteSubject(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }
    }
}