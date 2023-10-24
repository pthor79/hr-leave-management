using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
public record GetLeaveRequestDetailQuery(int id) : IRequest<LeaveRequestDetailDto>
{ 
    public int Id { get; set; }
}

