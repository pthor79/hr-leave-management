using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository) => _leaveAllocationRepository = leaveAllocationRepository;

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data

        //Retrieve record from database
        var leaveAllocationToDelete = await _leaveAllocationRepository.GetByIdAsync(request.Id);

        //Verify that record exists
        if (leaveAllocationToDelete is null)
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);

        //Save to database
        await _leaveAllocationRepository.DeleteAsync(leaveAllocationToDelete);

        //return record id
        return Unit.Value;
    }
}
