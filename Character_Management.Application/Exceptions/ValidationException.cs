using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public List<string> ErrorsList { get; set; } = new List<string>();
        public ValidationException(ValidationResult validationResult)
        {
            
            foreach(var error in validationResult.Errors)
            {
                ErrorsList.Add(error.ErrorMessage);
            }
        }

    }
}
