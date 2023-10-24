using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeavRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
internal class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    public UpdateLeaveRequestCommandHandler(IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveRequestRepository leaveRequestRepository,
        IAppLogger<UpdateLeaveTypeCommandHandler> logger,
        IEmailSender emailSender)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        _logger = logger;
        _emailSender = emailSender;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data
        var validator = new UpdateLeaveRequestCommandValidator(_leaveTypeRepository, _leaveRequestRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveRequest), request.Id);
            throw new BadRequestException("Invalid LeaveType", validationResult);
        }

        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest is null)
        {
            _logger.LogWarning("Entity could not be found in db for {0} - {1}", nameof(LeaveRequest), request.Id);
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);
        }

        //Map incoming data to domain object
        _mapper.Map(request, leaveRequest);

        //Save to database
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        try
        {
            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been updated to {leaveRequest.Approved}.",
                Subject = "Leave Request Updated"
            };

            await _emailSender.SendEmail(email);
        }
        catch (Exception)
        {
            _logger.LogError("Failed to send email, but leave request was updated successfully");
            throw;
        }

        //return record id
        return Unit.Value;
    }
}
