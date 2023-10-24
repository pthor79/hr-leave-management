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

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    public CreateLeaveAllocationCommandHandler(IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data
        var validator = new CreateLeaveAllocationCommandValidator(_leaveAllocationRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Allocation Request", validationResult);

        //Get leave type for allocations
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

        //Get Employees

        //Get Period

        //Map incoming data to domain object
        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

        //Save to database
        await _leaveAllocationRepository.CreateAsync(leaveAllocation);

        //return record id
        return Unit.Value;
    }
}
