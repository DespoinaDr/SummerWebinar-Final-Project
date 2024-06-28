using SummerWebinarApp.Data;

namespace SummerWebinarApp.Services
{
    public interface IWebinarService
    {
        Task<IEnumerable<Webinar>> GetAllWebinarsAsync();
        Task<IEnumerable<Webinar>> GetWebinarsByTeacherIdAsync(int teacherId);
        Task<bool> AddWebinar(string descritpion, int teacherId);
        Task<bool> UpdateWebinar(int id, string description);
	}
}