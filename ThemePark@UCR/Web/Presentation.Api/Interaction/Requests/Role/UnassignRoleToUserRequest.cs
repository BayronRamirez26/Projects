namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.Role;

public record UnassignRoleToUserRequest(Guid UserId, Guid RoleId);
