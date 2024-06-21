using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Mappers;

[Mapper]
public partial class UserDtoMapper
{
    public static partial UserDto FromEntityToDto(User user);

    public static string UserNameToString(UserNameValueObject userNick) => userNick.Value;

    public static string PasswordToString(PasswordValueObject userPassword) => userPassword.Value;
    public static RoleDto RoleToDto(Role role) => new RoleDto(
        role.RoleId,
        role.RoleName.Value,
        role.Permissions.Select(PermissionToDto)
    );
    public static PermissionDto PermissionToDto(Permission permission) => new PermissionDto(
        permission.PermissionId,
        permission.PermissionDescription.Value
    );
}
