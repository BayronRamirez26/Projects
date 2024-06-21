using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities
{
    public class BuildingObject
    {
    	public GuidValueObject ObjectId { get; }
        public GuidValueObject LevelId { get; }
        public MediumName ObjectType { get; }
        public MediumName Plane { get; }
        public MediumName ObjectName { get; }
        public Size Length { get; }
        public Size Width { get; }
        public Size Height { get; }
        public Coordinate CenterX { get; }
        public Coordinate CenterY { get; }
        public Angle Rotation { get; }
        public Counter ColorAmount { get; }
        public Color Color1 { get; }
        public Color? Color2 { get; }
        public Color? Color3 { get; }
        public Counter? WallId { get; set; }
        public Level Level { get; set; } = null;

        public BuildingObject(
            GuidValueObject objectId,
            GuidValueObject levelId,
            MediumName objectType,
            MediumName plane,
            MediumName objectName,
            Size length,
            Size width,
            Size height,
            Coordinate centerX,
            Coordinate centerY,
            Angle rotation,
            Counter colorAmount,
            Color color1,
            Color? color2 = null,
            Color? color3 = null,
            Counter? wallId = null)
        {
            ObjectId = objectId;
            LevelId = levelId;
            ObjectType = objectType;
            Plane = plane;
            ObjectName = objectName;
            Length = length;
            Width = width;
            Height = height;
            CenterX = centerX;
            CenterY = centerY;
            Rotation = rotation;
            ColorAmount = colorAmount;
            Color1 = color1;
            Color2 = color2 ?? null;
            Color3 = color3 ?? null;
            WallId = wallId ?? null;
        }

        public static readonly BuildingObject Invalid = new(
            GuidValueObject.Invalid,
            GuidValueObject.Invalid,
            MediumName.Invalid,
            MediumName.Invalid,
            MediumName.Invalid,
            Size.Invalid,
            Size.Invalid,
            Size.Invalid,
            Coordinate.Invalid,
            Coordinate.Invalid,
            Angle.Invalid,
            Counter.Invalid,
            Color.Invalid);
    }
}
