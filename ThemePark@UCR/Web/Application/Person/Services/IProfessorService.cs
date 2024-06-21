using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;

public interface IProfessorService
{
    public Task<IEnumerable<Professor>> GetProfessorsAsync();
    public Task<Professor> GetProfessorByIdAsync(Guid professorId);
    public Task<bool> DeactivateProfessorAsync(Guid professorId);
    public Task<bool> AssignPersonToProfessorAsync(Guid personId, InstitutionalEmailValueObject institutionalEmail);
}
