using HotelManagement.Domain.Repositories;
using HotelManagement.Infra.Context;
using HotelManagement.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HotelManagement.Infra
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfra(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DB_CONNECTION"];

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddDbContext<HotelDbContext>(options => options.UseNpgsql(connectionString));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
