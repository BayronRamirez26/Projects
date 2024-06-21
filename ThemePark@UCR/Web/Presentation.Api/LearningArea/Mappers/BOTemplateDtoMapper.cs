using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;

[Mapper]
internal partial class BOTemplateDtoMapper
{
    internal static partial BOTemplateDto FromEntity(BOTemplate boTemplate);

    internal static Guid FromGuidValueObject(GuidValueObject templateId)
    {
        return templateId.Value;
    }

    internal static string FromMediumName(MediumName mediumName)
    {
        return mediumName.Value;
    }

    internal static double FromSize(Size size)
    {
        return size.Value;
    }

    internal static byte FromCounter(Counter counter)
    {
        return counter.Value;
    }

    internal static string FromColor(Color color)
    {
        return color.Value;
    }

    internal static string? FromMediumNameNullable(MediumName? mediumName)
    {
        return mediumName?.Value;
    }

    internal static string? FromColorNullable(Color? color)
    {
        return color?.Value;
    }
}
