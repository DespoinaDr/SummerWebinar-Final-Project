namespace SummerWebinarApp.Repositories
{
    // Interface defining a unit of work for managing repositories
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public StudentRepository StudentRepository { get; }
        public TeacherRepository TeacherRepository { get; }
        public WebinarRepository WebinarRepository { get; }

        Task<bool> SaveAsync();
    }
}
