using WebApplication1.App.BAL.Services;
using WebApplication1.App.DAL.DALRepositories;

namespace WebApplication1.App.DAL
{
    public static class DALRepositoriesServices
    {
        public static IServiceCollection AddDALRepositoriesServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepositoryDAL, UserRepositoryDAL>();
            // services.AddScoped<IUserRepository, UserRepository>();
            // Add other user-related services

            return services;
        }
    }
}
