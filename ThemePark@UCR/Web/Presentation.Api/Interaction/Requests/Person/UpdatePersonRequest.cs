namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.Person;

public record UpdatePersonRequest(Guid PersonId, string FirstName, string? MiddleName, string FirstLastName, string? SecondLastName, DateOnly? BirthDate, string? PhoneNumber, string? Email);
