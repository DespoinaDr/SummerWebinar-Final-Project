using AutoMapper;
using SummerWebinarApp.Repositories;

namespace SummerWebinarApp.Services
{

    // Application service that provides access to various domain services.
    public class ApplicationService : IApplicationService
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService>? _logger;


        // Initializes a new instance of the ApplicationService class.
        public ApplicationService(IUnitOfWork unitOfWork, ILogger<UserService>? logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        // Gets the user service instance.
        public UserService UserService => new(_unitOfWork, _logger, _mapper);

        // Gets the student service instance.
        public StudentService StudentService => new(_unitOfWork, _logger, _mapper);

        // Gets the teacher service instance.
        public TeacherService TeacherService => new(_unitOfWork, _logger, _mapper);

        // Gets the webinar service instance.
        public WebinarService WebinarService => new(_unitOfWork, _logger, _mapper);
    }
}
