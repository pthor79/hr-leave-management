using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

//public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
//{

//}

/// <summary>
/// record is imutable
/// </summary>
public record GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>;


