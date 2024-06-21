using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;

public interface IStudentService
{
    public Task<IEnumerable<Student>> GetStudentsAsync();

    public Task<Student> GetStudentByIdAsync(Guid studentId);

    public Task<bool> DeactivateStudentAsync(Guid studentId);

    public Task<bool> AssignPersonToStudentAsync(Guid personId, string studentCard);
}
