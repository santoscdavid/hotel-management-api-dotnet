using AutoMapper;
using HotelManagement.Application.Dtos.Admins;
using HotelManagement.Domain.Entities;

namespace HotelManagement.Application.Mappings
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee!.Name));

            CreateMap<CreateAdminDto, Admin>();
            CreateMap<UpdateAdminDto, Admin>();
        }
    }
}
