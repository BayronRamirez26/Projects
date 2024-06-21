using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.Role;

public record CreateRoleWithPermissionsRequest(string RoleName, List<Guid?> permissionIds);
