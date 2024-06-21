using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Mappers;

[Mapper]
public partial class PermissionDtoMapper
{
    public static partial PermissionDto FromEntityToDto(Permission permission);

    public static string PermissionDescriptionnToString(MediumName permissionDesc) => permissionDesc.Value;
}
