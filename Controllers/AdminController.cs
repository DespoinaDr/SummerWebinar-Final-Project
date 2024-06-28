using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerWebinarApp.Data;
using SummerWebinarApp.DTO;
using SummerWebinarApp.Services;
using SummerWebinarApp.Models;

namespace SummerWebinarApp.Controllers
{
    public class AdminController : Controller
    {
        // Properties for storing DTOs, errors, and pagination details
        public List<UserDTO>? UsersDTO { get; set; } = new();
        public List<Error> ErrorArray { get; set; } = new();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        private readonly IMapper? _mapper;
        private readonly IApplicationService _applicationService;

        // Constructor injecting application service
        public AdminController(IApplicationService applicationService)
            : base()
        {
            _applicationService = applicationService;
        }
        // Action method handling POST requests to the index endpoint
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(UserFiltersDTO userFiltersDTO)
        {
            int pageSize = PageSize;
            int pageNumber = PageNumber;

            try
            {
                // Attempt to parse query parameters for pagination
                _ = int.TryParse(Request.Query["pagenumber"], out pageNumber);
                _ = int.TryParse(Request.Query["pagesize"], out pageSize);

                // Retrieve filtered users from the service layer
                List<User> users = await _applicationService.UserService.GetAllUsersFiltered(pageNumber,
                    pageSize, userFiltersDTO);

                // Map each User entity to UserDTO using AutoMapper and add to UsersDTO list
                foreach (var user in users)
                {
                    UserDTO? userDTO = _mapper!.Map<UserDTO>(user);
                    UsersDTO!.Add(userDTO);
                }
            }
            catch (Exception e)
            {
                // If an exception occurs, create an Error object and store in ErrorArray
                ErrorArray = new() {
                    new Error("", e.Message, "")
                };
            }

            return View(); // Return the default view (assuming there is a corresponding view)
        }
    }
}
