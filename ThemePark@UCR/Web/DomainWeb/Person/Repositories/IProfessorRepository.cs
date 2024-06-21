using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;

public interface IProfessorRepository
{
    public Task<IEnumerable<Professor>> GetProfessorsAsync();
    public Task<Professor> GetProfessorByIdAsync(Guid professorId);
    public Task<bool> DeactivateProfessorAsync(Guid professorId);
    public Task<bool> AssignPersonToProfessorAsync(Guid personId, Professor professor);

}
