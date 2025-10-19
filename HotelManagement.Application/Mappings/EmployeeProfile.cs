using AutoMapper;
using HotelManagement.Application.Dtos.Employees;
using HotelManagement.Domain.Entities;

namespace HotelManagement.Application.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeSummaryDto>();
        }
    }
}
