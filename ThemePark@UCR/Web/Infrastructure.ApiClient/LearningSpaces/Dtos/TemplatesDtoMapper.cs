using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;

/// <summary>
/// This class allow to make convertion from kiota entities to domain entities of LearningSpaces
/// </summary>
[Mapper]
public static partial class TemplatesDtoMapper
{
    /// <summary>
    /// This method allow to convert: Models.LearningSpaces -> DomainWeb.LearningSpaces
    /// </summary>
    /// <param name="learningSpace">Models.LearningSpaces requiered to convert</param>
    /// <returns>DomainWeb.LearningSpaces neccesary</returns>
    public static partial DomainWeb.LearningSpace.Entities.Templates ToEntity(Models.Templates learningSpace);

    /// <summary>
    /// This method allow to convert: Models.MediumName -> Domain.MediumName
    /// </summary>
    /// <param name="mediumName">Models.MediumName requiered to convert</param>
    /// <returns>Domain.MediumName neccesary</returns>
    public static MediumName ToValueObject(Models.MediumName mediumName)
    {
        return MediumName.Create(mediumName.Value);
    }

    /// <summary>
    /// This method allow to convert: Models.ShortName -> Domain.ShortName
    /// </summary>
    /// <param name="shortName">Models.ShortName requiered to convert</param>
    /// <returns>Domain.ShortName neccesary</returns>
    public static DoubleWrapper ToValueObject(Models.DoubleWrapper doublewrapper)
    {
        return DoubleWrapper.Create(doublewrapper.Value.Value);
    }
}
