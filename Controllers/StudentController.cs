using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerWebinarApp.DTO;
using SummerWebinarApp.Services;
using System.Security.Claims;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SummerWebinarApp.Models;


namespace SummerWebinarApp.Controllers
{

    // Controller class for student-specific actions
    public class StudentController : Controller
    {

        private readonly IApplicationService _applicationService;
        private readonly ILogger<StudentController> _logger;
      

        public StudentController(IApplicationService applicationService, ILogger<StudentController> logger)
        {
            _applicationService = applicationService;
            _logger = logger;
           
        }

        [Authorize(Roles = "Student")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        public async Task<ActionResult> Webinars()
        {
            var webinars = await _applicationService.WebinarService.GetAllWebinarsAsync();
            return View(webinars); // Return the default view associated with this action
        }

        public System.Security.Principal.IIdentity? GetIdentity()
        {
            return User.Identity;
        }

   

    }
}
