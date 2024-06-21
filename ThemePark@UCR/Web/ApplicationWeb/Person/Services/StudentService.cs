using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IPersonRepository _personRepository;

    public StudentService(IStudentRepository studentRepository, IPersonRepository personRepository)
    {
        _studentRepository = studentRepository;
        _personRepository = personRepository;
    }

    public Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return _studentRepository.GetStudentsAsync();
    }

    public Task<Student> GetStudentByIdAsync(Guid studentId)
    {
        return _studentRepository.GetStudentByIdAsync(studentId);
    }

    public async Task<bool> DeactivateStudentAsync(Guid studentId)
    {
        return await _studentRepository.DeactivateStudentAsync(studentId);
    }
    public async Task<bool> AssignPersonToStudentAsync(Guid personId, string studentCard)
    {
        var person = await _personRepository.GetPersonByIdAsync(personId);
        if (person == null)
        {
            throw new ArgumentException("Person does not exist.");
        }

        var student = new Student(
            Guid.NewGuid(),
            personId,
            new StudentCardValueObject(studentCard),
            true);

        return await _studentRepository.AssignPersonToStudentAsync(personId, student);
    }
}

