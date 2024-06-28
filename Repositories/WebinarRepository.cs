using Microsoft.EntityFrameworkCore;
using SummerWebinarApp.Data;

namespace SummerWebinarApp.Repositories
{

    // Repository for managing Webinar entities.
    public class WebinarRepository : BaseRepository<Webinar>, IWebinarRepository
    {
        public WebinarRepository(SummerWebinarDbContext context)
                   : base(context)
        {
        }

		public async Task<List<Webinar>> GetWebinarsByTeacherIdAsync(int teacherId)
		{
			var webinars = await _context.Webinars
					   .Where(w => w.TeacherId == teacherId)
					   .ToListAsync();

			return webinars;
		}

		// Retrieves students associated with a webinar asynchronously.
		public async Task<List<Student>> GetWebinarStudentsAsync(int id)
        {
            List<Student> webinars;
            webinars = await _context.Webinars
                       .Where(w => w.Id == id)
                       .SelectMany(w => w.Students!)
                       .ToListAsync();
            return webinars;
        }

        // Retrieves the teacher associated with a webinar asynchronously.

        public async Task<Teacher?> GetWebinarTeacherAsync(int id)
        {
            var webinar = await _context.Webinars
                            .Where(w => w.Id == id)
                            .FirstOrDefaultAsync();

            if (webinar == null)
            {
                return null;
            }

            if (webinar.Teacher is null)
            {
                return null;
            }

            return webinar.Teacher;
        }

        public async Task<bool> AddWebinar(string descritpion, int teacherId)
        {
            try
            {
                var webinar = new Webinar() { Description = descritpion, TeacherId = teacherId };
                await AddAsync(webinar);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

		public async Task<bool> UpdateWebinar(int id, string description)
		{
			try
			{
                var webinar = await GetAsync(id);
                if (webinar == null)
                    return false;

                webinar.Description = description;
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
