using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeavRequest.Commands.UpdateLeaveRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : Controller
{
    private readonly IMediator _mediator;

    public LeaveRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveTypesController>
    [HttpGet]
    public async Task<List<LeaveRequestDto>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveRequestListQuery());
        return leaveTypes;
    }

    // GET: api/<LeaveTypesController>/id
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDetailDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveRequestDetailQuery(id));
        return Ok(leaveType);
    }

    // POST: api/<LeaveTypesController>/id
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateLeaveRequestCommand leaveRequest)
    {
        var response = await _mediator.Send(leaveRequest);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    // PUT: api/<LeaveTypesController>/id
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateLeaveRequestCommand leaveRequest)
    {
        await _mediator.Send(leaveRequest);
        return NoContent();
    }

    [HttpPut]
    [Route("CancelRequest")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CancelRequest(CancelLeaveRequestCommand cancelLeaveRequest)
    {
        await _mediator.Send(cancelLeaveRequest);
        return NoContent();
    }

    [HttpPut]
    [Route("UpdateApproval")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateApproval(UpdateLeaveRequestCommand updateLeaveRequest)
    {
        await _mediator.Send(updateLeaveRequest);
        return NoContent();
    }

    // DELETE: api/<LeaveTypesController>/id
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveRequestCommand { Id = id});
        return NoContent();
    }
}
