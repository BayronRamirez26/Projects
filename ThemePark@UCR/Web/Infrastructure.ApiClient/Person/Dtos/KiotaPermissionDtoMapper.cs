using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper]
internal static partial class KiotaPermissionDtoMapper
{
    internal static partial Permission ToEntity(DomainWeb.Person.Entities.Permission permission);

    internal static MediumName ToValueObject(DomainWeb.Shared.ValueObjects.MediumName permissionDescription)
    {

        var output = new MediumName();
        output.Value = permissionDescription.Value;
        return output;
    }
}
