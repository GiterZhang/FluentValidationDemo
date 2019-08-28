using FluentValidation;
using FluentValidationDemoForAspNetCore.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationDemoForAspNetCore.Validator
{
    public class AddStudentInputValidator : AbstractValidator<AddStudentInput>, IValidator<AddStudentInput>
    {
        public AddStudentInputValidator(IValidator<AddPersonInput> addPersonInputValidator)
        {
            //继承
            base.Include(addPersonInputValidator);

            //complex prop
            RuleFor(x => x.Class.ClassName).NotNull();
            //collection

        }
    }
}
