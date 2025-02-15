using WebApplication1.App.BAL.Services;

namespace WebApplication1.App.DataTransferLayer
{
    public static class DataTransferLayerServices
    {
        public static IServiceCollection AddDatTransferLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
           // services.AddScoped<IUserRepository, UserRepository>();
            // Add other user-related services

            return services;
        }

    }
}
