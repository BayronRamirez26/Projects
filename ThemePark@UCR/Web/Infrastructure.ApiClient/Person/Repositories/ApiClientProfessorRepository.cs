using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.AssignPersonToProfessor.AssignPersonToProfessorRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Repositories;

public class ApiClientProfessorRepository : IProfessorRepository
{
    private readonly ApiClientKiota _apiClient;

    public ApiClientProfessorRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<bool> AssignPersonToProfessorAsync(Guid personId, Professor professor)
    {
        try
        {
            // Map the student object to the API student model using KiotaStudentDtoMapper
            var studentModel = KiotaProfessorDtoMapper.ToEntity(professor);

            // Create a request object or configure the request parameters as needed by your API
            var requestConfiguration = new Action<RequestConfiguration<AssignPersonToProfessorRequestBuilderPostQueryParameters>>(config =>
            {
                config.QueryParameters = new AssignPersonToProfessorRequestBuilderPostQueryParameters
                {
                    PersonId = personId
                };


            });

            var response = await _apiClient.AssignPersonToProfessor.PostAsync(requestConfiguration);

            return response ?? throw new NullReferenceException();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error assigning person to student: {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeactivateProfessorAsync(Guid professorId)
    {
        try
        {
            var requestBuilder = _apiClient.DeactivateProfessor[professorId];

            var response = await requestBuilder.PostAsync();

            if (response == null)
            {
                throw new NullReferenceException("API response is null");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deactivating student: {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }


    public async Task<Professor> GetProfessorByIdAsync(Guid professorId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Professor>> GetProfessorsAsync()
    {
        var response = await _apiClient.GetProfessors.GetAsync(); //Para poder hacer await de un task, el método debe estar como async
        var professorsEntities = response?.Professors?.Select(ProfessorDtoMapper.ToEntity)
            ?? throw new NullReferenceException();
        return professorsEntities;
    }
}
