using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeavRequest.Commands.DeleteLeaveRequest;
public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository) => _leaveRequestRepository = leaveRequestRepository;

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data

        //Retrieve record from database
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        //Verify that record exists
        if (leaveRequest is null)
            throw new NotFoundException(nameof(LeaveRequest), request.Id);

        //Save to database
        await _leaveRequestRepository.DeleteAsync(leaveRequest);

        //return record id
        return Unit.Value;
    }
}
