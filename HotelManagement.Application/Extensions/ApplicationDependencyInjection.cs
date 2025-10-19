using System.Reflection;
using FluentValidation;
using HotelManagement.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(RoomProfile).Assembly);
            services.AddAutoMapper(cfg => { }, typeof(GuestProfile).Assembly);
            services.AddAutoMapper(cfg => { }, typeof(ReservationProfile).Assembly);
            services.AddAutoMapper(cfg => { }, typeof(EmployeeProfile).Assembly);
            services.AddAutoMapper(cfg => { }, typeof(HotelProfile).Assembly);
            services.AddAutoMapper(cfg => { }, typeof(AdminProfile).Assembly);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}