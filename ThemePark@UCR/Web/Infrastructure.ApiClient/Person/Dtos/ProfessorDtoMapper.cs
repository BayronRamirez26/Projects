using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper] // Esto es para que Mapper haga la generalización automática

internal static partial class ProfessorDtoMapper
{
    internal static partial DomainWeb.Person.Entities.Professor ToEntity(ProfessorDto professorDto);

    internal static DomainWeb.Person.ValueObjects.InstitutionalEmailValueObject ToInstitutionalEmailDto(string? institutionalEmailDto)
    {
        return DomainWeb.Person.ValueObjects.InstitutionalEmailValueObject.Create(institutionalEmailDto);
    }
}
