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

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IAppLogger<GetLeaveRequestListQueryHandler> _logger;

    public GetLeaveRequestListQueryHandler(IMapper mapper,
        ILeaveRequestRepository leaveRequestRepository,
        IAppLogger<GetLeaveRequestListQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _logger = logger;
    }

    public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();

        //convert data objects to DTO objects
        var requests = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);

        _logger.LogInformation("Leave request were retrieve successfully");

        //return list of DTO objects
        return requests;
    }
}
