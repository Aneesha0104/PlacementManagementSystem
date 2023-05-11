using PMS.BLL;
using PMS.DAL;

namespace PMS
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {

            // Data Repos
            services.AddScoped<IUserRepository, UserRepository>();


            // Services
            services.AddScoped<IUserBLL, UserBLL>();


            return services;
        }
    }
}
