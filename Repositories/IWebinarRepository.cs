using SummerWebinarApp.Data;

namespace SummerWebinarApp.Repositories
{
    // Interface defining repository operations specific to webinars
    public interface IWebinarRepository
    {
        Task<List<Student>> GetWebinarStudentsAsync(int id);
        Task<Teacher?> GetWebinarTeacherAsync(int id);
        Task<List<Webinar>> GetWebinarsByTeacherIdAsync(int teacherId);
        Task<bool> AddWebinar(string descritpion, int teacherId);
        Task<bool> UpdateWebinar(int id, string description);
	}
}
