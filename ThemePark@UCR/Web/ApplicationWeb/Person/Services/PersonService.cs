using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Task<bool> CreatePersonAsync(Persons person)
    {

        return _personRepository.CreatePersonAsync(person);
    }

    public Task<bool> DeletePersonAsync(Guid personId)
    {
        return _personRepository.DeletePersonAsync(personId);
    }

    public Task<IEnumerable<Persons>> GetPersonAsync()
    {
        return _personRepository.GetPersonAsync();
    }

    public Task<bool> UpdatePersonAsync(Persons person)
    {
        return _personRepository.UpdatePersonAsync(person);
    }
}
