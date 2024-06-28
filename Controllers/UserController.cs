using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SummerWebinarApp.DTO;
using SummerWebinarApp.Models;
using SummerWebinarApp.Services;
using System.Security.Claims;

namespace SummerWebinarApp.Controllers
{
    public class UserController : Controller
    {
        public List<Error> ErrorArray { get; set; } = new();

        private readonly IApplicationService _applicationService;

        // Constructor injecting application service
        public UserController(IApplicationService applicationService)
            : base()
        {
            _applicationService = applicationService;
        }
        // GET: Returns the signup view
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        // POST: Handles user signup
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignupDTO userSignupDTO)
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState.Values)
                {
                    foreach (var error in entry.Errors)
                    {
                        ErrorArray!.Add(new Error("", error.ErrorMessage, ""));
                    }
                }
                ViewData["ErrorArray"] = ErrorArray;
                return View(); ; // Return to the form with validation errors
            }

            try
            {
                // Attempt to sign up the user
                await _applicationService.UserService.SignUpUserAsync(userSignupDTO);
                return RedirectToAction("Login", "User");
            }
            catch (Exception e)
            {
                ErrorArray!.Add(new Error("", e.Message, ""));
                ViewData["ErrorArray"] = ErrorArray;
                return View();
            }
        }
        // GET: Returns the login view
        [HttpGet]
        public IActionResult Login()
        {
            // Redirect authenticated users to their respective dashboards
            ClaimsPrincipal principal = HttpContext.User;
            if (principal.Identity!.IsAuthenticated)
            {
                if (principal.FindFirst(ClaimTypes.Role)!.Value == "Teacher")
                {
                    return RedirectToAction("Index", "Teacher");
                }
                else if (principal.FindFirst(ClaimTypes.Role)!.Value == "Student")
                {
                    return RedirectToAction("Index", "Student");
                }
                else if (principal.FindFirst(ClaimTypes.Role)!.Value == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(); // Return login view for non-authenticated users
        }
        // POST: Handles user login
        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDTO credentials)
        {
            var user = await _applicationService.UserService.VerifyAndGetUserAsync(credentials);
            if (user == null)
            {
                ViewData["ValidateMessage"] = "Error: User/Password not found ";
                return View();
            }

            // Create claims for authentication
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, credentials.Username!),
                new Claim(ClaimTypes.Role, user.UserRole!.ToString()!),
                new Claim("UserId", user.Id.ToString())
            };

            // Create identity and authentication properties
            ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new()
            {
                AllowRefresh = true,
                IsPersistent = credentials.KeepLoggedIn
            };

            // Sign in user with cookie authentication
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(identity), properties);

            // Redirect user based on their role after successful login
            if (user.UserRole == UserRole.Teacher)
            {
                return RedirectToAction("Index", "Teacher");
            }
            else if (user.UserRole == UserRole.Student)
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
            //return RedirectToAction("Index", "Home");
        }

        // GET: Handles user logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
