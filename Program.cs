using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SummerWebinarApp.Configuration;
using SummerWebinarApp.Data;
using SummerWebinarApp.Repositories;
using SummerWebinarApp.Services;

namespace SummerWebinarApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Configure Serilog
			builder.Host.UseSerilog((context, config) =>
			{
				config.ReadFrom.Configuration(context.Configuration);
			});

			// Configure database connection
			var connString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDbContext<SummerWebinarDbContext>(options => options.UseSqlServer(connString));

			// Configure AutoMapper
			builder.Services.AddAutoMapper(typeof(MapperConfig));

			// Register application services
			builder.Services.AddScoped<IApplicationService, ApplicationService>();
			builder.Services.AddRepositories();

			// Add controllers with views
			builder.Services.AddControllersWithViews();

			// Configure authentication
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = "/User/Login";
					options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
				});

			var app = builder.Build();

			// Configure the HTTP request pipeline
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication(); // Ensure authentication middleware is added
			app.UseAuthorization();

			// Enable Serilog request logging
			app.UseSerilogRequestLogging();

			// Configure default route
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
