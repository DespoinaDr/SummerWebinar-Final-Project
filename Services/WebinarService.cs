using AutoMapper;
using SummerWebinarApp.Data;
using SummerWebinarApp.Repositories;

namespace SummerWebinarApp.Services
{

	// Service class for handling webinar-related operations.
	public class WebinarService : IWebinarService
    {

        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<UserService>? _logger;

        public WebinarService(IUnitOfWork? unitOfWork, ILogger<UserService>? logger, IMapper? mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // Retrieves all webinars for a specific teacher asynchronously.
        public async Task<IEnumerable<Webinar>> GetWebinarsByTeacherIdAsync(int teacherId)
        {
            List<Webinar> webinars = new();
            try
            {
                webinars = (await _unitOfWork!.WebinarRepository.GetWebinarsByTeacherIdAsync(teacherId)).ToList();
                _logger!.LogInformation("{Message}", "All webinars returned with success");
            }
            catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
            }
            return webinars;
        }

		// Retrieves all students asynchronously.
		public async Task<IEnumerable<Webinar>> GetAllWebinarsAsync()
		{
			List<Webinar> webinars = new();
			try
			{
				webinars = (await _unitOfWork!.WebinarRepository.GetAllAsync()).ToList();
				foreach (var webinar in webinars)
				{
					webinar.Teacher = await _unitOfWork!.TeacherRepository.GetAsync(webinar.TeacherId);
				}
				_logger!.LogInformation("{Message}", "All webinars returned with success");
			}
			catch (Exception e)
			{
				_logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
			}
			return webinars;
		}

		public async Task<Webinar> GetWebinarAsync(int id)
		{
			Webinar webinar = null;
			try
			{
				webinar =  await _unitOfWork!.WebinarRepository.GetAsync(id);		
				_logger!.LogInformation("{Message}", "All webinars returned with success");
			}
			catch (Exception e)
			{
				_logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
			}
			return webinar!;
		}

		public async Task<bool> AddWebinar(string descritpion, int teacherId)
        {
            return await _unitOfWork!.WebinarRepository.AddWebinar(descritpion, teacherId);
		}

		public async Task<bool> UpdateWebinar(int id, string description)
		{
			return await _unitOfWork!.WebinarRepository.UpdateWebinar(id, description);
		}
	}
}
