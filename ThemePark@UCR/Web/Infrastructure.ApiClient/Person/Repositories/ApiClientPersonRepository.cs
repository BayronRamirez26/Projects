using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.DeletePerson.DeletePersonRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Repositories;

public class ApiClientPersonRepository : IPersonRepository
{

    private readonly ApiClientKiota _apiClient;

    public ApiClientPersonRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }
    public async Task<bool> CreatePersonAsync(DomainWeb.Person.Entities.Persons person)
    {
        try
        {
            var createPerson = KiotaPersonDtoMapper.ToCreatePersonRequest(person);

            try
            {
                var output = await _apiClient.CreatePerson.PostAsync(createPerson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public async Task<bool> DeletePersonAsync(Guid personId)
    {
        var requestConfiguration = new Action<RequestConfiguration<DeletePersonRequestBuilderDeleteQueryParameters>>(config =>
        {
            config.QueryParameters = new DeletePersonRequestBuilderDeleteQueryParameters
            {
                PersonId = personId
            };
        });

        var deleteLevelResponse = await _apiClient.DeletePerson.DeleteAsync(requestConfiguration);

        return deleteLevelResponse ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<DomainWeb.Person.Entities.Persons>> GetPersonAsync()
    {
        var response = await _apiClient.GetPersons.GetAsync();
        var personEntities = response?. Person?.Select(PersonDtoMapper.ToEntity)
            ?? throw new NullReferenceException();
        return personEntities;
    }

    public Task<Persons?> GetPersonByIdAsync(Guid personId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdatePersonAsync(DomainWeb.Person.Entities.Persons person)
    {
        try
        {
            var updatePerson = KiotaPersonDtoMapper.ToUpdatePersonRequest(person);
            try
            {
                var output = await _apiClient.UpdatePerson.PutAsync(updatePerson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;


    }

}
