using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

/// <summary>
/// record is imutable
/// </summary>
public record GetLeaveTypeDetailsQuery(int id) : IRequest<LeaveTypeDetailsDto>;


