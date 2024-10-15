using backend.Models;

namespace backend.Services;

public interface IStudentWorkService
{
    List<StudentWork> GetAllStudentWorks();

    IEnumerable<StudentWork> GetStudentWorksBySubmitDateTime(DateTime submitDateTime);

    int GetSubmissionCountBySubmitDateTime(DateTime submitDateTime);
    
    List<SubjectProgress> GetAverageProgressOfSubjectBySubmitDateTime(DateTime submitDateTime);

    List<StudentPerformance> GetStudentPerformancesBySubmitDateTime(DateTime submitDateTime);
}
