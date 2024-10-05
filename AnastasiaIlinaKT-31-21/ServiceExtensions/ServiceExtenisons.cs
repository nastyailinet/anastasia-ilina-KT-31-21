using AnastasiaIlinaKT_31_21.Interfaces.AcademicGroupsInterfaces;
using AnastasiaIlinaKT_31_21.Interfaces.MarksInterfaces;

namespace AnastasiaIlinaKT_31_21.ServiceExtensions
{
    public static class ServiceExtenisons
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAcademicGroupService, AcademicGroupService>();
            services.AddScoped<IAvgGroupMarkService, AvgGroupMarkService>();
            services.AddScoped<IStudentMarkService, StudentMarkService>();
            services.AddScoped<IAvgYearMarkService, AvgYearMarkService>();

            return services;
        }
    }
}
