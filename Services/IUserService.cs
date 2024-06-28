using SummerWebinarApp.Data;
using SummerWebinarApp.DTO;

namespace SummerWebinarApp.Services
{

    // Interface defining operations related to user management.
    public interface IUserService
    {

        // Registers a new user asynchronously.
        Task SignUpUserAsync(UserSignupDTO request);
        Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials);
        Task<User?> UpdateUserAsync(int userId, UserDTO userDTO);
        Task<User?> UpdateUserPatchAsync(int userId, UserPatchDTO request);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<int> GetTeacherIdByUserIdAsync(int userId);

		// Retrieves all users filtered by specific criteria asynchronously.
		Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize,
            UserFiltersDTO userFiltersDTO);
    }
}

