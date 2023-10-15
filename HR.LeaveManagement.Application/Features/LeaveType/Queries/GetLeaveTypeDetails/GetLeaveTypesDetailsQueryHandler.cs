using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypesDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        //Query the database
        var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.id);

        //verify that record exists
        if(leaveTypeDetails is null)
            throw new NotFoundException(nameof(LeaveType), request.id);

        //convert data objects to DTO objects
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetails);

        //return list of DTO objects
        return data;
    }
}

