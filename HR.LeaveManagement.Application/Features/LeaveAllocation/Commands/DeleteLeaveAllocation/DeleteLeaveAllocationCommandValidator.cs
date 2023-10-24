using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
public class DeleteLeaveAllocationCommandValidator : AbstractValidator<DeleteLeaveAllocationCommand>
{
    public DeleteLeaveAllocationCommandValidator(ILeaveAllocationRepository leaveAllocationRepository)
    {
        RuleFor(p => p.Id)
            .NotEqual(0).WithMessage("{PropertyName} must not be 0");
    }
}
