using SummerWebinarApp.Data;


namespace SummerWebinarApp.Services
{

    // Interface defining operations related to students.
    public interface IStudentService
    {
        Task<IEnumerable<User>> GetAllStudentsAsync();
        Task<List<Webinar>> GetStudentWebinarsAsync(int id);
        Task<Student?> GetStudentAsync(int id);
        Task<bool> DeleteStudentAsync(int id);
        Task<int> GetStudentCountAsync();

    }
}
