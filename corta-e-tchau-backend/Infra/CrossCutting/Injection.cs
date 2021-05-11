using corta_e_tchau_backend.Domain.Notification;
using corta_e_tchau_backend.Repository;
using corta_e_tchau_backend.Service;
using Microsoft.Extensions.DependencyInjection;

namespace corta_e_tchau_backend.Infra
{
    public class Injection
    {
        public static void Configure(IServiceCollection services)
        {

            // Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISchedulingService, SchedulingService>();

            // Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            

            services.AddScoped<NotificationContext>();
        }
    }
}
