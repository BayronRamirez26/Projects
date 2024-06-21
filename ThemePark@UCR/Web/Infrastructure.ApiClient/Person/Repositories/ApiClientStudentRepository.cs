using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.AssignPersonToStudent.AssignPersonToStudentRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Repositories;

internal class ApiClientStudentRepository : IStudentRepository
{
    private readonly ApiClientKiota _apiClient;

    public ApiClientStudentRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<bool> AssignPersonToStudentAsync(Guid personId, DomainWeb.Person.Entities.Student student)
    {
        try
        {
            // Map the student object to the API student model using KiotaStudentDtoMapper
            var studentModel = KiotaStudentDtoMapper.ToEntity(student);

            // Create a request object or configure the request parameters as needed by your API
            var requestConfiguration = new Action<RequestConfiguration<AssignPersonToStudentRequestBuilderPostQueryParameters>>(config =>
            {
                config.QueryParameters = new AssignPersonToStudentRequestBuilderPostQueryParameters
                {
                    PersonId = personId
                };
            });

            var response = await _apiClient.AssignPersonToStudent.PostAsync(requestConfiguration);

            return response ?? throw new NullReferenceException();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error assigning person to student: {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeactivateStudentAsync(Guid studentId)
    {
        try
        {        
            var requestBuilder = _apiClient.DeactivateStudent[studentId];

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

    public async Task<Student> GetStudentByIdAsync(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        var response = await _apiClient.GetStudents.GetAsync(); //Para poder hacer await de un task, el método debe estar como async
        var studentsEntities = response?.Students?.Select(StudentDtoMapper.ToEntity)
            ?? throw new NullReferenceException();
        return studentsEntities;
    }

}
