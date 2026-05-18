using Microsoft.EntityFrameworkCore;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;
using Primary_High_School.DAL;

namespace Primary_And_High_School.Services.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Primary_And_HighDbContext _context;

        public StudentRepository(Primary_And_HighDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students
                .Include(s => s.Subjects)
                .ThenInclude(s => s.Books)
                .ToList();
        }

        public Student? GetStudentByNumber(string studentNumber)
        {
            return _context.Students
                .Include(s => s.Subjects)
                .ThenInclude(s => s.Books)
                .FirstOrDefault(s => s.StudentNumber == studentNumber);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(string studentNumber)
        {
            var student = _context.Students.Find(studentNumber);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}