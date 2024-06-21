using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper] // Esto es para que Mapper haga la generalización automática
internal static partial class PermissionDtoMapper
{
    internal static partial DomainWeb.Person.Entities.Permission ToEntity(PermissionDto permissionDto);

    internal static DomainWeb.Shared.ValueObjects.MediumName ToPermissiobDescriptionDto(string permissionDescriptionDto)
    {
        return DomainWeb.Shared.ValueObjects.MediumName.Create(permissionDescriptionDto);
    }

}
