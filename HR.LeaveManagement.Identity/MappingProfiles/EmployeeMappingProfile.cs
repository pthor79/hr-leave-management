using AutoMapper;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;

namespace HR.LeaveManagement.Identity.MappingProfiles;
public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, ApplicationUser>();
    }    
}
