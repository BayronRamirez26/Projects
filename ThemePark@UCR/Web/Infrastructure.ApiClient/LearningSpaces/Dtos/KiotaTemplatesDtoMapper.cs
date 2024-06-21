using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;

/// <summary>
/// This class allow to convert from domain entities to kiota entities of LearningSpaces
/// </summary>
[Mapper]
public static partial class KiotaTemplatesDtoMapper
{

    /// <summary>
    /// /// This method allow to convert: DomainWeb.LearningSpaces -> Models.LearningSpaces
    /// </summary>
    /// <param name="learningSpace">DomainWeb.LearningSpaces requiered to convert</param>
    /// <returns>Models.LearningSpaces neccesary</returns>
    public static partial Models.Templates ToEntity(DomainWeb.LearningSpace.Entities.Templates learningSpace);

    /// <summary>
    /// This method allow to convert: Domain.MediumName -> Models.MediumName
    /// </summary>
    /// <param name="mediumName">Domain.MediumName requiered to convert</param>
    /// <returns>Models.MediumName neccesary</returns>
    public static Models.MediumName ToValueObject(MediumName mediumName)
    {
        var output = new Models.MediumName();
        output.Value = mediumName.Value;
        return output;
    }

    /// <summary>
    /// This method allow to convert: Domain.DoubleWrapper -> Models.DoubleWrapper
    /// </summary>
    /// <param name="doubleWrapper">Domain.DoubleWrapper requiered to convert</param>
    /// <returns>Models.DoubleWrapper neccesary</returns>
    public static Models.DoubleWrapper ToValueObject(DoubleWrapper doubleWrapper)
    {
        var output = new Models.DoubleWrapper();
        output.Value = doubleWrapper.Value;
        return output;
    }

    
}
