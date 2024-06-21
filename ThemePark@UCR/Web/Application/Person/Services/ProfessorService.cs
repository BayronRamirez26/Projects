using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;

public class ProfessorService : IProfessorService
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IPersonRepository _personRepository;

    public ProfessorService(IProfessorRepository professorRepository, IPersonRepository personRepository)
    {
        _professorRepository = professorRepository;
        _personRepository = personRepository;
    }

    public Task<IEnumerable<Professor>> GetProfessorsAsync()
    {
        return _professorRepository.GetProfessorsAsync();
    }

    public Task<Professor> GetProfessorByIdAsync(Guid professorId)
    {
        return _professorRepository.GetProfessorByIdAsync(professorId);
    }

    public async Task<bool> DeactivateProfessorAsync(Guid professorId)
    {
        return await _professorRepository.DeactivateProfessorAsync(professorId);
    }

    public async Task<bool> AssignPersonToProfessorAsync(Guid personId, InstitutionalEmailValueObject institutionalEmail)
    {
        var person = await _personRepository.GetPersonByIdAsync(personId);
        if (person == null)
        {
            throw new ArgumentException("Person does not exist.");
        }

        var professor = new Professor(
            Guid.NewGuid(),
            personId,
            institutionalEmail,
            true
        );

        return await _professorRepository.AssignPersonToProfessorAsync(personId, professor);
    }
}
