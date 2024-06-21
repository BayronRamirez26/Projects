namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

public record ProfessorDto(Guid professorId, Guid personId, string? institutionalEmail, bool isActive);
