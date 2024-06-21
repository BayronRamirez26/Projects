using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;

[Mapper]
public static partial class Template_Has_ComponentsDtoMapper
{
    public static DomainWeb.LearningSpace.Entities.Template_Has_Components ToEntity(Models.Template_Has_Components dto)
    {
        return new DomainWeb.LearningSpace.Entities.Template_Has_Components(
            ToValueObject(dto.Id),
            ToValueObject(dto.ComponentType),
            ToValueObject(dto.Template),
            ToValueObject(dto.SizeX),
            ToValueObject(dto.SizeY),
            ToValueObject(dto.PositionX),
            ToValueObject(dto.PositionY),
            ToValueObject(dto.PositionZ),
            ToValueObject(dto.RotationX),
            ToValueObject(dto.RotationY)
        );
    }

    public static DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper ToValueObject(Models.GuidWrapper guidWrapper)
    {
        return guidWrapper.Value != null ? DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper.Create(guidWrapper.Value.Value) : DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper.Create(Guid.NewGuid());
    }

    public static DomainWeb.Shared.ValueObjects.MediumName ToValueObject(Models.MediumName mediumName)
    {
        //if (mediumName == null || string.IsNullOrEmpty(mediumName.Value))
        //{
        //    throw new ArgumentException("Invalid mediumName value");
        //}

        return DomainWeb.Shared.ValueObjects.MediumName.Create(mediumName.Value);
    }

    public static DomainWeb.LearningSpace.Entities.Wrappers.DoubleWrapper ToValueObject(Models.DoubleWrapper doubleWrapper)
    {
        return doubleWrapper.Value != null ? DomainWeb.LearningSpace.Entities.Wrappers.DoubleWrapper.Create(doubleWrapper.Value.Value) : DomainWeb.LearningSpace.Entities.Wrappers.DoubleWrapper.Create(0.0);
    }




}
