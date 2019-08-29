using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationDemoForAspNetCore.Validator.ValidatorInterceptor
{
    /// <summary>
    /// CustomValidatorInterceptor
    /// </summary>
    public class MyValidatorInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
        {
            //after Validation
            using (var file = File.Open("log.txt", FileMode.OpenOrCreate))
            {
                var log = "after validation";
                var bytes = Encoding.UTF8.GetBytes($"{DateTime.Now}:{log}\r\n");
                file.Seek(file.Length, SeekOrigin.Begin);
                file.Write(bytes, 0, bytes.Length);
            }
            return result;
        }

        public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
        {
            //before Validation
            using (var file = File.Open("log.txt", FileMode.OpenOrCreate))
            {
                var log = "before validation";
                var bytes = Encoding.UTF8.GetBytes($"{DateTime.Now}:{log}\r\n");
                file.Seek(file.Length, SeekOrigin.Begin);
                file.Write(bytes, 0, bytes.Length);
            }
            return validationContext;
        }
    }
}
