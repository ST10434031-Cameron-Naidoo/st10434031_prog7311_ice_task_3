using Primary_And_High_School.Domain;

namespace Primary_And_High_School.Services.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student? GetStudentByNumber(string studentNumber);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(string studentNumber);
    }
}