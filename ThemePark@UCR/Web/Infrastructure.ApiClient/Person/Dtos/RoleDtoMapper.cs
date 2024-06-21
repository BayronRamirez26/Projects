using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;


namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper] // Esto es para que Mapper haga la generalización automática
internal static partial class RoleDtoMapper
{
    internal static partial DomainWeb.Person.Entities.Role ToEntity(RoleDto roleDto);

    internal static DomainWeb.Shared.ValueObjects.MediumName ToRoleNameDto(string roleNameDto)
    {
        return DomainWeb.Shared.ValueObjects.MediumName.Create(roleNameDto);
    }

}
