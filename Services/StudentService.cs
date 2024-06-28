using AutoMapper;
using SummerWebinarApp.Data;
using SummerWebinarApp.Repositories;

namespace SummerWebinarApp.Services
{
    // Service class for handling student-related operations.
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<UserService>? _logger;

        public StudentService(IUnitOfWork? unitOfWork, ILogger<UserService>? logger, IMapper? mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }



        // Deletes a student asynchronously by ID.
        public async Task<bool> DeleteStudentAsync(int id)
        {
            bool studentDeleted = false;
            try
            {
                studentDeleted = await _unitOfWork!.StudentRepository.DeleteAsync(id);
                _logger!.LogInformation("{Message}", "Student with id:  " + id + " deleted, success");
            }
            catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
            }
            return studentDeleted;
        }


        // Retrieves all students asynchronously.
        public async Task<IEnumerable<User>> GetAllStudentsAsync()
        {
            List<User> usersStudents = new();
            try
            {
                //students = await _unitOfWork!.StudentRepository.GetAllAsync();
                usersStudents = await _unitOfWork!.StudentRepository.GetAllUsersStudentsAsync();
                _logger!.LogInformation("{Message}", "All students returned with success");
            }
            catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
            }
            return usersStudents;
        }


        // Retrieves a student by ID asynchronously.
        public async Task<Student?> GetStudentAsync(int id)
        {
            Student? student = null;
            try
            {
                student = await _unitOfWork!.StudentRepository.GetAsync(id);
                _logger!.LogInformation("{Message}", "Student with id: " + id + " retrieved with success");
            }
            catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
            }
            return student;
        }

        public async Task<int> GetStudentCountAsync()
        {
            int count = 0;
            try
            {
                count = await _unitOfWork!.StudentRepository.GetCountAsync();
                _logger!.LogInformation("{Message}", "Student count retrieved with success");
            }
            catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
            }
            return count;
        }

        // Retrieves webinars associated with a student asynchronously.
        public async Task<List<Webinar>> GetStudentWebinarsAsync(int id)
        {
            List<Webinar> webinars = new();

            try
            {
                webinars = await _unitOfWork!.StudentRepository.GetStudentWebinarsAsync(id);
                _logger!.LogInformation("{Message}", "Student count retrieved with success");
            }
            catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
            }
            return webinars;
        }

    }
}
