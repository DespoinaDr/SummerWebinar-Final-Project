using Microsoft.Extensions.DependencyModel;

namespace SummerWebinarApp.Repositories
{
    // Extension class for registering repositories in dependency injection
    public static class RepositoriesDIExtensions
    {
        // Extension method to add repositories to the service collection
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
