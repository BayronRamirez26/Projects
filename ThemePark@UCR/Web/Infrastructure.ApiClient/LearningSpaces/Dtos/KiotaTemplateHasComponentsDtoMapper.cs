using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;

/// <summary>
/// This class allow to convert from domain entities to kiota entities of LearningSpaces
/// </summary>
[Mapper]
public static partial class KiotaTemplate_Has_ComponentDtoMapper
{

    /// <summary>
    /// /// This method allow to convert: DomainWeb.LearningSpaces -> Models.LearningSpaces
    /// </summary>
    /// <param name="learningSpace">DomainWeb.LearningSpaces requiered to convert</param>
    /// <returns>Models.LearningSpaces neccesary</returns>
    // public static partial Models.Template_Has_Components ToEntity(DomainWeb.LearningSpace.Entities.Template_Has_Components template_Has_components);

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

    public static Models.Template_Has_Components ToEntity(DomainWeb.LearningSpace.Entities.Template_Has_Components domainEntity)
    {
        return new Models.Template_Has_Components
        {
            Id = ToValueObject(domainEntity.Id),
            ComponentType = ToValueObject(domainEntity.Component_type),
            Template = ToValueObject(domainEntity.Template),
            SizeX = ToValueObject(domainEntity.SizeX),
            SizeY = ToValueObject(domainEntity.SizeY),
            PositionX = ToValueObject(domainEntity.PositionX),
            PositionY = ToValueObject(domainEntity.PositionY),
            PositionZ = ToValueObject(domainEntity.PositionZ),
            RotationX = ToValueObject(domainEntity.RotationX),
            RotationY = ToValueObject(domainEntity.RotationY)
        };
    }

}
