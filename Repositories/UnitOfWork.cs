using SummerWebinarApp.Data;

namespace SummerWebinarApp.Repositories
{

    // Implementation of the Unit of Work pattern for managing repositories.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SummerWebinarDbContext _context;

        public UnitOfWork(SummerWebinarDbContext context)
        {
            _context = context;
        }


        // Repository for managing User entities.
        public UserRepository UserRepository => new(_context);
        public StudentRepository StudentRepository => new(_context);
        public TeacherRepository TeacherRepository => new(_context);
        public WebinarRepository WebinarRepository => new(_context);


        // Saves changes asynchronously to the underlying database
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
