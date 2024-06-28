using Microsoft.EntityFrameworkCore;
using SummerWebinarApp.Data;
using SummerWebinarApp.Models;

namespace SummerWebinarApp.Repositories
{

    // Repository for accessing and managing Teacher entities.
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SummerWebinarDbContext context)
            : base(context)
        {
        }

        public async Task<Teacher?> GetByPhoneNumber(string? phoneNumber)
        {
            return await _context.Teachers.Where(s => s.PhoneNumber == phoneNumber)
                .FirstOrDefaultAsync()!;
        }

		public async Task<Teacher?> GetByUserId(int userId)
		{
            return await _context.Teachers.FirstOrDefaultAsync(s => s.UserId == userId);
		}

		public async Task<List<Webinar>> GetTeacherWebinarsAsync(int id)
        {
            List<Webinar> webinars;
            webinars = await _context.Teachers
                       .Where(t => t.Id == id)
                       .SelectMany(t => t.Webinars!)
                       .ToListAsync();
            return webinars;
        }

        public async Task<List<User>> GetAllUsersTeachersAsync()
        {
            var usersWithTeacherRole = await _context.Users
                   .Where(u => u.UserRole == UserRole.Teacher)
                   .Include(u => u.Teacher) // Teacher is the navigation property
                   .ToListAsync();

            return usersWithTeacherRole;
        }

        // Retrieves a paged list of users with the role of teacher asynchronously.
        public async Task<List<User>> GetAllUsersTeachersAsync(int pageNumber, int pageSize)
        {
            int skip = pageSize * pageNumber;
            var usersWithTeacherRole = await _context.Users
                   .Where(u => u.UserRole == UserRole.Teacher)
                   .Include(u => u.Teacher) // Teacher is the navigation property
                   .Skip(skip)
                   .Take(pageSize)
                   .ToListAsync();

            return usersWithTeacherRole;
        }

        // Retrieves a teacher user by their username asynchronously.
        public async Task<User?> GetTeacherByUsernameAync(string username)
        {
            var userTeacher = await _context.Users
            .Where(u => u.Username == username && u.UserRole == UserRole.Teacher)
            .SingleOrDefaultAsync();

            return userTeacher;
        }
    }
}
