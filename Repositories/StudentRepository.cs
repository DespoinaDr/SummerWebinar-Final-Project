using Microsoft.EntityFrameworkCore;
using SummerWebinarApp.Data;
using SummerWebinarApp.Models;

namespace SummerWebinarApp.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {

        //Repository class for managing student-related data operations.
        // Inherits base repository functionality for database operations.
        public StudentRepository(SummerWebinarDbContext context)
            : base(context)
        {
        }

        public async Task<Student?> GetByPhoneNumber(string? phoneNumber)
        {
            return await _context.Students.Where(s => s.PhoneNumber == phoneNumber)
                .FirstOrDefaultAsync()!;
        }

        public async Task<List<Webinar>> GetStudentWebinarsAsync(int id)
        {
            List<Webinar> webinars;
            webinars = await _context.Students
                       .Where(s => s.Id == id)
                       .SelectMany(s => s.Webinars!)
                       .ToListAsync();
            return webinars;
        }

        public async Task<List<User>> GetAllUsersStudentsAsync()
        {
            var usersWithStudentRole = await _context.Users
                   .Where(u => u.UserRole == UserRole.Student)
                   .Include(u => u.Student)
                   .ToListAsync();

            return usersWithStudentRole;
        }
      

    }
}
