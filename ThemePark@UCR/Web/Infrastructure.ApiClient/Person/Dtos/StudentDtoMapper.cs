using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper] // Esto es para que Mapper haga la generalización automática

internal static partial class StudentDtoMapper
{
    internal static partial DomainWeb.Person.Entities.Student ToEntity(StudentDto studentDto);

    internal static DomainWeb.Person.ValueObjects.StudentCardValueObject ToInstitutionalEmailDto(string? studentCardDto)
    {
        return DomainWeb.Person.ValueObjects.StudentCardValueObject.Create(studentCardDto);
    }
}
