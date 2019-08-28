using FluentValidationDemoForAspNetCore.Input;

namespace FluentValidationDemoForAspNetCore.Interface
{
    public interface IPersonService
    {
        int AddPerson(AddPersonInput input);

        int AddStudent(AddStudentInput input);
    }
}
