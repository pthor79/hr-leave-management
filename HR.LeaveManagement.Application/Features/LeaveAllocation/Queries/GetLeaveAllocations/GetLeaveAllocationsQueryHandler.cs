using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IAppLogger<GetLeaveAllocationsQueryHandler> _logger;

    public GetLeaveAllocationsQueryHandler(IMapper mapper,
        ILeaveAllocationRepository leaveAllocationRepository,
        IAppLogger<GetLeaveAllocationsQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _logger = logger;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();

        //convert data objects to DTO objects
        var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

        _logger.LogInformation("Leave types were retrieve successfully");

        //return list of DTO objects
        return allocations;
    }
}
