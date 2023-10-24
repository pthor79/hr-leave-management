﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    
    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) => _leaveTypeRepository = leaveTypeRepository;


    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data
                
        //Retrieve record from database
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

        //Verify that record exists
        if (leaveTypeToDelete is null)
            throw new NotFoundException(nameof(LeaveType), request.Id);

        //Save to database
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

        //return record id
        return Unit.Value;
    }
}
