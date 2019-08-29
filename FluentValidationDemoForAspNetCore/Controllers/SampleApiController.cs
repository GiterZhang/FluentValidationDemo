using FluentValidation.AspNetCore;
using FluentValidationDemoForAspNetCore.Input;
using FluentValidationDemoForAspNetCore.Interface;
using FluentValidationDemoForAspNetCore.Validator.ValidatorInterceptor;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemoForAspNetCore.Controllers
{
    [ApiController]
    public class SampleApiController : ControllerBase
    {
        private readonly IPersonService _personService;
        public SampleApiController(IPersonService personService)
        {
            _personService = personService;
        }
        /// <summary>
        /// add a person
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("api/person")]
        public int AddPersion(AddPersonInput input) => _personService.AddPerson(input);

        /// <summary>
        /// add a student
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("api/student"), ]
        public int AddStudent([CustomizeValidator(Interceptor = typeof(MyValidatorInterceptor))]AddStudentInput input) => _personService.AddStudent(input);
    }
}
