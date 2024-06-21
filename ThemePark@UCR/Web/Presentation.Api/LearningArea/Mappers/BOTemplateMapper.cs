using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;

[Mapper]
internal partial class BOTemplateMapper
{
    internal static partial BOTemplate ToEntity(BOTemplateDto boTemplate);

    internal static GuidValueObject ToGuidValueObjectVO(Guid templateId)
    {
        return GuidValueObject.Create(templateId);
    }

    internal static MediumName ToMediumNameVO(string mediumName)
    {
        return MediumName.Create(mediumName);
    }

    internal static Size ToSizeVO(double size)
    {
        return Size.Create(size);
    }

    internal static Counter ToCounterVO(byte counter)
    {
        return Counter.Create(counter);
    }

    internal static Color ToColorVO(string color)
    {
        return Color.Create(color);
    }

    internal static MediumName? ToMediumNameNullableVO(string? mediumName)
    {
        return mediumName is null ? null : MediumName.Create(mediumName);
    }

    internal static Color? ToColorNullableVO(string? color)
    {
        return color is null ? null : Color.Create(color);
    }
}
