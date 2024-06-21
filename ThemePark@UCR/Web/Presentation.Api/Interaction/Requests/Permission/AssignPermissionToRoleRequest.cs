namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.Permission;

public record AssignPermissionToRoleRequest(Guid RoleId, Guid PermissionId);
