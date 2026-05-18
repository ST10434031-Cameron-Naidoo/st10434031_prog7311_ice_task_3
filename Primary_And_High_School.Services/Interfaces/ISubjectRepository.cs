using Primary_And_High_School.Domain;

namespace Primary_And_High_School.Services.Interfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetAllSubjects();
        Subject? GetSubjectById(int id);
        void AddSubject(Subject subject);
        void UpdateSubject(Subject subject);
        void DeleteSubject(int id);
    }
}