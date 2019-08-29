using FluentValidation;
using FluentValidation.Results;
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
            RuleForEach(x => x.Courses).Must(x => !string.IsNullOrEmpty(x.Name)).WithMessage("课程名称不能为空");                

            //async validation
            RuleFor(x => x.School).MustAsync(async (school, cancellation) => {
                return await IsSchoolExist(school);
            });
            
            //custom rule
            RuleFor(x => x.Courses).Custom((x, context) => {
                if (x?.Count < 10)
                    context.AddFailure("至少选10门课程");
            });

        }

        public async Task<bool> IsSchoolExist(string schoolName)
        {
            await Task.Delay(1000);
            return !string.IsNullOrEmpty(schoolName);
        }
        /// <summary>
        /// PreValidate
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected override bool PreValidate(ValidationContext<AddStudentInput> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
                return false;
            else 
                return true;
        }
    }
}
