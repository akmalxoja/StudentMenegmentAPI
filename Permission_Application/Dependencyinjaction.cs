using Microsoft.Extensions.DependencyInjection;
using VehicleManagement_Application.Services.EmailSender;

namespace Permission_Application
{
    public static class Dependencyinjaction
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IForgetEmail, ForgetEmail>();
            return services;
        }

    }
}
