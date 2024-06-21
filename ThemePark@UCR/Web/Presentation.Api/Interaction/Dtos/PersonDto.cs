namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

public record PersonDto(Guid PersonId, string FirstName, string? MiddleName,
    string FirstLastName, string? SecondLastName, string? BirthDate,
    string? PhoneNumber, string? Email, UserDto? User);
