using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Exceptions;
public class BadRequestException: Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = new();
        foreach (var validationError in validationResult.Errors)
        {
            ValidationErrors.Add(validationError.ErrorMessage);
        }
    }

    public List<string> ValidationErrors { get; set; }
}
