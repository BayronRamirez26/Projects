namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.User;

public record CreateUserRequest(string UserNickName, string UserPasswordHash, Guid PersonId);

