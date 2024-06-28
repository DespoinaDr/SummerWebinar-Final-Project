using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerWebinarApp.DTO;
using SummerWebinarApp.Models;
using SummerWebinarApp.Services;
using System.Security.Claims;


namespace SummerWebinarApp.Controllers
{
	// Controller class for teacher-specific actions
	public class TeacherController : Controller
	{
		private readonly IApplicationService _applicationService;
		private readonly ILogger<TeacherController> _logger; 

		public TeacherController(IApplicationService applicationService, ILogger<TeacherController> logger)
		{
			_applicationService = applicationService;
			_logger = logger; 
		}

		[Authorize(Roles = "Teacher")]
		public IActionResult Index()
		{
			return View(); // Return the default view associated with this action
		}


		[Authorize(Roles = "Teacher")]
		public IActionResult AddWebinar()
		{
			return View(); // Return the default view associated with this action
		}

		[Authorize(Roles = "Teacher")]
		[HttpPost]
		public async Task<IActionResult> AddWebinar(AddWebinarDTO data)
		{
			ClaimsPrincipal principal = HttpContext.User;
			var userId = Convert.ToInt32(principal.FindFirst("UserId")!.Value);

			var teacherId = await _applicationService.UserService.GetTeacherIdByUserIdAsync(userId);
			var result = await _applicationService.WebinarService.AddWebinar(data.Description, teacherId);

			return View();
		}

		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> EditWebinar(int id)
		{
			var result = await _applicationService.WebinarService.GetWebinarAsync(id);
			if (result == null)
			{
				return NotFound(); // Return 404 if the webinar is not found
			}
			return View(result);
		}

		[Authorize(Roles = "Teacher")]
		[HttpPost]
		public async Task<IActionResult> EditWebinar(EditWebinarDTO data)
		{
			if (!ModelState.IsValid)
			{
				return View(data); // Return to the same view with the data if there is a validation error
			}

			try
			{
				var result = await _applicationService.WebinarService.UpdateWebinar(data.Id, data.Description);
				if (result)
				{
					return RedirectToAction("Webinars"); // Redirect to the list of webinars after successful update
				}
				else
				{
					ModelState.AddModelError("", "An error occurred while updating the webinar.");
					return View(data);
				}
			}
			catch (Exception ex)
			{

				// Logging the error
				_logger.LogError(ex, "An error occurred while updating the webinar with ID {WebinarId}", data.Id);
				ModelState.AddModelError("", "An unexpected error occurred.");
				return View(data);
			}
		}

		[Authorize(Roles = "Teacher")]
		public async Task<ActionResult> Webinars()
		{
			ClaimsPrincipal principal = HttpContext.User;
			var userId = Convert.ToInt32(principal.FindFirst("UserId")!.Value);

			var teacherId = await _applicationService.UserService.GetTeacherIdByUserIdAsync(userId);
			var webinars = await _applicationService.WebinarService.GetWebinarsByTeacherIdAsync(teacherId);
			return View(webinars); // Return the default view associated with this action
		}
	}
}
