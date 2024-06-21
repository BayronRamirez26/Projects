using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper]
internal static partial class KiotaStudentDtoMapper
{
    internal static partial Student ToEntity(DomainWeb.Person.Entities.Student student);

    internal static StudentCardValueObject ToValueObject(DomainWeb.Person.ValueObjects.StudentCardValueObject studentCard)
    {
        var output = new StudentCardValueObject();
        output.Value = studentCard.Value;
        return output;
    }
}
