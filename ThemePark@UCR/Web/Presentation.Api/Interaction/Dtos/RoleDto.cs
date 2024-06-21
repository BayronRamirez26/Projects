namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

public record RoleDto(Guid RoleId, string RoleName, IEnumerable<PermissionDto> Permissions);