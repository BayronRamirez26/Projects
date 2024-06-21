using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;

/// <summary>
/// This class allow to convert from domain entities to kiota entities of LearningSpaces
/// </summary>
[Mapper]
public static partial class KiotaLearningSpaceDtoMapper
{

    /// <summary>
    /// /// This method allow to convert: DomainWeb.LearningSpaces -> Models.LearningSpaces
    /// </summary>
    /// <param name="learningSpace">DomainWeb.LearningSpaces requiered to convert</param>
    /// <returns>Models.LearningSpaces neccesary</returns>
    public static partial Models.LearningSpaces ToEntity(DomainWeb.LearningSpace.Entities.LearningSpaces learningSpace);

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
    /// This method allow to convert: Domain.ShortName -> Models.ShortName
    /// </summary>
    /// <param name="mediumShortName">Domain.ShortName requiered to convert</param>
    /// <returns>Models.ShortName neccesary</returns>
    public static Models.ShortName ToValueObject(ShortName mediumShortName)
    {
        var output = new Models.ShortName();
        output.Value = mediumShortName.Value;
        return output;
    }

    /// <summary>
    /// This method allow to convert: Domain.GuidWrapper -> Models.GuidWrapper
    /// </summary>
    /// <param name="guidWrapper">Domain.GuidWrapper requiered to convert</param>
    /// <returns>Models.GuidWrapper neccesary</returns>
    public static Models.GuidWrapper ToValueObject(GuidWrapper guidWrapper)
    {
        var output = new Models.GuidWrapper();
        output.Value = guidWrapper.Value;
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
