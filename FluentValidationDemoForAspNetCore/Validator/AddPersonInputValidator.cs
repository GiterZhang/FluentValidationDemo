using FluentValidation;
using FluentValidationDemoForAspNetCore.Input;
using System;
using System.IO;
using System.Text;

namespace FluentValidationDemoForAspNetCore.Validator
{
    public class AddPersonInputValidator : AbstractValidator<AddPersonInput>, IValidator<AddPersonInput>
    {
        public AddPersonInputValidator()
        {
            //1.for simple prop
            RuleFor(x => x.Name).NotEmpty().WithMessage(x => "姓名不能为空");
            RuleFor(x => x.Age).GreaterThanOrEqualTo(0).WithMessage(x => $"年龄不能小于0！当前{x.Age}");
            RuleFor(x => x.IDCard).Length(18).WithMessage(x => "身份证必须为18位！");

            //Enum validator
            RuleFor(x => x.ManType).IsInEnum().WithMessage("{PropertyName}超过枚举定义范围");


            RuleFor(x => x.Age).GreaterThan(18).When(x => x.ManType.Equals(Input.ManType.Adult) || x.ManType.Equals(Input.ManType.Old))
                .WithMessage("成人必须大于18岁");
            RuleFor(x => x.IDCard).Must(x => x.StartsWith("310"))
                .When(x => "上海".Equals(x.Province?.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .WithMessage("上海人身份证必须以310开头！")
                .OnFailure((x, context, errorMessage)=> {
                    //call back
                    using (var file = File.Open("error_log.txt", FileMode.OpenOrCreate))
                    {
                        var bytes = Encoding.UTF8.GetBytes(errorMessage + "\r\n");
                        file.Seek(file.Length, SeekOrigin.Begin);
                        file.Write(bytes, 0, bytes.Length);
                    }    
                });

        }
    }
}
