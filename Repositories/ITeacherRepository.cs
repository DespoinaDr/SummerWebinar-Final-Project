using SummerWebinarApp.Data;

namespace SummerWebinarApp.Repositories
{

    // Interface defining repository operations specific to teachers
    public interface ITeacherRepository
    {
        Task<List<Webinar>> GetTeacherWebinarsAsync(int id);
        Task<Teacher?> GetByPhoneNumber(string? phoneNumber);
        Task<Teacher?> GetByUserId(int userId);

		Task<List<User>> GetAllUsersTeachersAsync();
        Task<List<User>> GetAllUsersTeachersAsync(int pageNumber, int pageSize);
        Task<User?> GetTeacherByUsernameAync(string username);
    }
}
