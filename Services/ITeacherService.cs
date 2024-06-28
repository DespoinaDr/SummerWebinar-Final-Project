using SummerWebinarApp.Data;

namespace SummerWebinarApp.Services
{

    // Interface defining operations related to teachers
    public interface ITeacherService
    {

        // Retrieves all users with the teacher role asynchronously.
        Task<List<User>> GetAllUsersTeachersAsync();

        // Retrieves a paginated list of users with the teacher role asynchronously.
        Task<List<User>> GetAllUsersTeachersAsync(int pageNumber, int pageSize);

        // Retrieves the total count of teachers asynchronously.
        Task<int> GetTeacherCountAsync();

        // Retrieves a teacher by their username asynchronously.
        Task<User?> GetTeacherByUsernameAsync(string? username);
    }
}
