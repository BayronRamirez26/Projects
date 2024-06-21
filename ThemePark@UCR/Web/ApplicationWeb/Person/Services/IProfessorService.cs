using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;

public interface IProfessorService
{
    public Task<IEnumerable<Professor>> GetProfessorsAsync();
    public Task<Professor> GetProfessorByIdAsync(Guid professorId);
    public Task<bool> DeactivateProfessorAsync(Guid professorId);
    public Task<bool> AssignPersonToProfessorAsync(Guid personId, InstitutionalEmailValueObject institutionalEmail);
}
