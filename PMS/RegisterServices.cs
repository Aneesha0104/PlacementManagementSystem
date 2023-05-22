using Microsoft.Extensions.DependencyInjection.Extensions;
using PMS.BLL;
using PMS.DAL;

namespace PMS
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Data Repos
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICollegeRepository, CollegeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();


            // Services
            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<ICollegeBLL, CollegeBLL>();
            services.AddScoped<ICompanyBLL, CompanyBLL>();

            return services;
        }
    }
}
