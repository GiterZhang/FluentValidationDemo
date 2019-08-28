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
            //inherit
            base.Include(addPersonInputValidator);

            RuleFor(x => x.Courses).NotNull();

            //complex prop
            RuleFor(x => x.Class.ClassName).NotNull();

            //collection
            RuleForEach(x => x.Courses).NotNull()
                .OnFailure(x => {
                    //call back
                    //log 

                });


            //async validation
            RuleFor(x => x.School).MustAsync(async (school, cancellation) => {
                return await IsSchoolExist(school);
            });

        }

        public async Task<bool> IsSchoolExist(string schoolName)
        {
            await Task.Delay(1000);
            return !string.IsNullOrEmpty(schoolName);
        }
    }
}
