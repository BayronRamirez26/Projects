using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper]
internal static partial class KiotaRoleDtoMapper
{

    internal static partial Role ToEntity(DomainWeb.Person.Entities.Role roleDto);

    internal static MediumName ToValueObject(DomainWeb.Shared.ValueObjects.MediumName rolename)
    {

        var output = new MediumName();
        output.Value = rolename.Value;
        return output;
    }

    internal static CreateRoleRequest ToCreateRoleRequest(DomainWeb.Person.Entities.Role role)
    {
        return new CreateRoleRequest
        {
            RoleName = role.RoleName.Value,
            RoleId = role.RoleId
        };
    }
}
