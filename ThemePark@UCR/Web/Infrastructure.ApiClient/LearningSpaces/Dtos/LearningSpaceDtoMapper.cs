using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;

/// <summary>
/// This class allow to make convertion from kiota entities to domain entities of LearningSpaces
/// </summary>
[Mapper]
public static partial class LearningSpaceDtoMapper
{
    /// <summary>
    /// This method allow to convert: Models.LearningSpaces -> DomainWeb.LearningSpaces
    /// </summary>
    /// <param name="learningSpace">Models.LearningSpaces requiered to convert</param>
    /// <returns>DomainWeb.LearningSpaces neccesary</returns>
    public static partial DomainWeb.LearningSpace.Entities.LearningSpaces ToEntity(Models.LearningSpaces learningSpace);

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
    public static ShortName ToValueObject(Models.ShortName shortName)
    {
        return ShortName.Create(shortName.Value);
    }

    /// <summary>
    /// This method allow to convert: Models.GuidWrapper -> Domain.GuidGrapper
    /// </summary>
    /// <param name="guidWrapper">Models.GuidWrapper requiered to convert</param>
    /// <returns>Domain.GuidWrapper neccesary</returns>
    public static GuidWrapper ToValueObject(Models.GuidWrapper guidWrapper)
    {
        if (guidWrapper.Value != null)
        {
            // If the Guid exist assign the already existing value
            return GuidWrapper.Create(guidWrapper.Value.Value);

        }
        else
        {
            // If no Guid is recieved create a new one
            return GuidWrapper.Create(Guid.NewGuid());
        }
    }

    /// <summary>
    /// This method allow to convert: Models.DoubleWrapper -> Domain.DoubleWrapper
    /// </summary>
    /// <param name="doubleWrapper">Models.DoubleWrapper requiered to convert</param>
    /// <returns>Domain.DoubleWrapper neccesary</returns>
    public static DoubleWrapper ToValueObject(Models.DoubleWrapper doubleWrapper)
    {
        return DoubleWrapper.Create(doubleWrapper.Value.Value);
        
    }
}
