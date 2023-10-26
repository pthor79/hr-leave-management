using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Services;
internal class UserService: IUserService
{
private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var users = await _userManager.GetUsersInRoleAsync("Employee");
        return _mapper.Map<List<Employee>>(users);
    }

    public async Task<Employee> GetEmployee(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return _mapper.Map<Employee>(user);
    }
}
