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
            services.AddScoped<ICollegeRepository, CollegeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();


            // Services
            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<ICollegeBLL, CollegeBLL>();
            services.AddScoped<ICompanyBLL, CompanyBLL>();
            services.AddScoped<IStudentBLL, StudentBLL>();  
            return services;
        }
    }
}
