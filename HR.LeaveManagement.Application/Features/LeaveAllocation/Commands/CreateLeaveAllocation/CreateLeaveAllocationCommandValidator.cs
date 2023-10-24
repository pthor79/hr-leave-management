﻿using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public CreateLeaveAllocationCommandValidator(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("{PropertyName} does not exist");

    }

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
    {
        var leaveType = await _leaveAllocationRepository.GetByIdAsync(id);
        return leaveType != null;
    }
}
