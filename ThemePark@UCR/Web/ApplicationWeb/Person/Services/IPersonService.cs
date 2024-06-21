/// IPersonService

using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;

public interface IPersonService
{
    public Task<bool> CreatePersonAsync(Persons person); // Se cambia los parámetros si no se hace con Dto

    public Task<IEnumerable<Persons>> GetPersonAsync();

    public Task<bool> UpdatePersonAsync(Persons person);
    public Task<bool> DeletePersonAsync(Guid personId);


}
