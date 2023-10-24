using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
public class DeleteLeaveRequestCommandValidator : AbstractValidator<DeleteLeaveRequestCommand>
{
    public DeleteLeaveRequestCommandValidator(ILeaveRequestRepository leaveRequestRepository)
    {
        RuleFor(p => p.Id)
            .NotEqual(0).WithMessage("{PropertyName} must not be 0");
    }
}
