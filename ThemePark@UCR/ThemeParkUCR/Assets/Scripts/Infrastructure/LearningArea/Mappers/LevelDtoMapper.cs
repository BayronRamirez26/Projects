using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningArea.Mappers
{
    [Mapper]
    internal static partial class LevelDtoMapper
    {
        internal static partial Domain.LearningArea.Entities.Level ToEntity(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.Level LevelDto);

        internal static GuidValueObject ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.GuidValueObject guidValueObjectDto)
        {
            return GuidValueObject.Create(guidValueObjectDto.Value);
        }

        internal static LongName ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.LongName longNameDto)
        {
            return LongName.Create(longNameDto.Value);
        }

        internal static MediumName ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.MediumName mediumNameDto)
        {
            return MediumName.Create(mediumNameDto.Value);
        }

        internal static ShortName ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.ShortName shortNameDto)
        {
            return ShortName.Create(shortNameDto.Value);
        }

        internal static Counter ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.Counter counterDto)
        {
            return Counter.Create((byte)counterDto.Value);
        }

        internal static Size ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.Size sizeDto)
        {
            return Size.Create((double)sizeDto.Value);
        }

        internal static Angle ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.Angle angleDto)
        {
            return Angle.Create((double)angleDto.Value);
        }

        internal static Coordinate ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.Coordinate coordinateDto)
        {
            return Coordinate.Create((double)coordinateDto.Value);
        }

        internal static Color ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.Color colorDto)
        {
            return Color.Create(colorDto.Value);
        }

    }
}
