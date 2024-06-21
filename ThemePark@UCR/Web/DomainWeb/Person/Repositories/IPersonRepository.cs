using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;

public interface IPersonRepository
{
    public Task<IEnumerable<Persons>> GetPersonAsync();

   public Task<Persons?> GetPersonByIdAsync(Guid personId);

    public Task<bool> CreatePersonAsync(Persons person);

    public Task<bool> UpdatePersonAsync(Persons person);
    public Task<bool> DeletePersonAsync(Guid personId);
}

