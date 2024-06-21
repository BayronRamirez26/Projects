using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Dtos;


/// <summary>
/// This class allow to convert from kiota entities to domain entities of LsType
/// </summary>
[Mapper]
public static partial class LsTypeDtoMapper
{

    /// <summary>
    /// /// This method allow to convert: Models.LstType -> Domain.LstType
    /// </summary>
    /// <param name="learningSpace">Models.LstType requiered to convert</param>
    /// <returns>Domain.LstType neccesary</returns>
    public static partial LSType ToEntity(Models.LSType learningSpace);

    /// <summary>
    /// This method allow to convert: Models.MediumName -> Domain.MediumName
    /// </summary>
    /// <param name="mediumName">Models.MediumName requiered to convert</param>
    /// <returns>Domain.MediumName neccesary</returns>
    public static MediumName ToValueObject(Models.MediumName mediumName)
    {
        return MediumName.Create(mediumName.Value);
    }
}
