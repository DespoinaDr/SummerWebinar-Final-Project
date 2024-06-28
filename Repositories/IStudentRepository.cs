using SummerWebinarApp.Data;

namespace SummerWebinarApp.Repositories
{

    // Interface defining repository operations specific to students
    public interface IStudentRepository
    {
        Task<List<Webinar>> GetStudentWebinarsAsync(int id);
        Task<Student?> GetByPhoneNumber(string? phoneNumber);
        Task<List<User>> GetAllUsersStudentsAsync();

    
    }
}
