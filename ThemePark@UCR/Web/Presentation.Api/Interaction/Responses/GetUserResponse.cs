using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Responses;

public record GetUserResponse(IEnumerable<UserDto> ActiveUsers)
{

}
