namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

public record UserDto(Guid UserId, string UserNickName, string UserPasswordHash, bool IsActive, Guid PersonId, IEnumerable<RoleDto> Roles);
