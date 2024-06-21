using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetStudentsAsync();
    public Task<Student> GetStudentByIdAsync(Guid studentId);
    public Task<bool> DeactivateStudentAsync(Guid studentId);
    public Task<bool> AssignPersonToStudentAsync(Guid personId, Student student);

}
