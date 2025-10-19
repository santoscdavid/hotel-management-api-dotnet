using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Application.Dtos.Employees
{
    public class EmployeeSummaryDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;
    }
}
