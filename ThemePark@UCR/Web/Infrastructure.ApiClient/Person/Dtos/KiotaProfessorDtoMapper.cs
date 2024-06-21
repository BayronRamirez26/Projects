using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper]
internal static partial class KiotaProfessorDtoMapper
{
    internal static partial Professor ToEntity(DomainWeb.Person.Entities.Professor user);

    internal static InstitutionalEmailValueObject ToValueObject(DomainWeb.Person.ValueObjects.InstitutionalEmailValueObject institutionalEmail)
    {
        var output = new InstitutionalEmailValueObject();
        output.Value = institutionalEmail.Value;
        return output;
    }
}
