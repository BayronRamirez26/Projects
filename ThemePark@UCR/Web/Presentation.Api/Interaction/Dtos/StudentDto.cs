namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

public record StudentDto (Guid studentId, Guid personId, string? studentCard, bool isActive);
