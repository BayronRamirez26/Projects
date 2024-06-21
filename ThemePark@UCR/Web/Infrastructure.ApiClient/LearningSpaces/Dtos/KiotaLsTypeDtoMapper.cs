using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningSpaces.Dtos;

/// <summary>
/// This class allow to convert from domain entities to kiota entities of LsType
/// </summary

[Mapper]
public static partial class KiotaLsTypeDtoMapper
{

    /// <summary>
    /// /// This method allow to convert: Domain.LstType -> Models.LstType
    /// </summary>
    /// <param name="learningSpace">Domain.LstType requiered to convert</param>
    /// <returns>Models.LstType neccesary</returns>
    public static partial Client.Models.LSType ToEntity(DomainWeb.LearningSpace.Entities.LSType learningSpace);

    /// <summary>
    /// This method allow to convert: Domain.MediumName -> Models.MediumName
    /// </summary>
    /// <param name="mediumName">Domain.MediumName requiered to convert</param>
    /// <returns>Models.MediumName neccesary</returns>
    public static Client.Models.MediumName ToValueObject(MediumName mediumName)
    {
        var output = new Client.Models.MediumName();
        output.Value = mediumName.Value;
        return output;
    }
}
