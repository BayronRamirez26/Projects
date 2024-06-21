using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Mappers;

[Mapper]
public partial class RoleDtoMapper
{
    public static partial RoleDto FromEntityToDto(Role role);

    public static string RoleNameToString(MediumName middleName) => middleName.Value;
    public static PermissionDto PermissionToDto(Permission permission) => new PermissionDto(
        permission.PermissionId,
        permission.PermissionDescription.Value
    );

}
