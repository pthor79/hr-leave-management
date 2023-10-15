using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
public class DeleteLeaveTypeCommandValidator : AbstractValidator<DeleteLeaveTypeCommand>
{
    public DeleteLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Id)
            .NotEqual(0).WithMessage("{PropertyName} must not be 0");
    }
}
