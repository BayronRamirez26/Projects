using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Mappers;

[Mapper]
public partial class ProfessorDtoMapper
{
    public static partial ProfessorDto FromEntityToDto(Professor professor);

    public static string InstitutionalEmailToString(InstitutionalEmailValueObject institutionalEmail) => institutionalEmail.Value;

}
