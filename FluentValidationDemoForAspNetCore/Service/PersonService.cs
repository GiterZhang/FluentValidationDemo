using FluentValidation;
using FluentValidationDemoForAspNetCore.Input;
using FluentValidationDemoForAspNetCore.Interface;
using System;

namespace FluentValidationDemoForAspNetCore.Service
{
    public class PersonService : IPersonService
    {
        private readonly IValidator<AddPersonInput> _addPersonInputValidator;
        private readonly IValidator<AddStudentInput> _addStudentInputValidator;
        public PersonService(IValidator<AddPersonInput> addPersonInputValidator, IValidator<AddStudentInput> addStudentInputValidator)
        {
            _addPersonInputValidator = addPersonInputValidator;
            _addStudentInputValidator = addStudentInputValidator;
        }
        public int AddPerson(AddPersonInput input)
        {
            if(_addPersonInputValidator != null)
            {
                //validation
                var result = _addPersonInputValidator.Validate(input);
                if (!result.IsValid)
                {
                    var fullErrorMessage = string.Join(";", result.Errors);
                    throw new Exception(fullErrorMessage);
                }
            }
            return 0;
        }

        public int AddStudent(AddStudentInput input)
        {
            if (_addStudentInputValidator != null)
            {
                //validation
                var result = _addStudentInputValidator.Validate(input);
                if (!result.IsValid)
                {
                    var fullErrorMessage = string.Join(";", result.Errors);
                    throw new Exception(fullErrorMessage);
                }
            }
            return 0;
        }
    }
}
