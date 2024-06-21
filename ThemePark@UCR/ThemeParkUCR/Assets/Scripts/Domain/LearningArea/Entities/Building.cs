using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities
{
    public class Building
    {
        public GuidValueObject BuildingId { get; }

        public LongName UniversityName { get; }

        public LongName CampusName { get; }

        public MediumName SiteName { get; }

        public ShortName BuildingAcronym { get; }

        public LongName BuildingName { get; }

        public Coordinate CenterX { get; }

        public Coordinate CenterY { get; }

        public Size Length { get; }

        public Size Width { get; }

        public Angle Rotation { get; }

        public Color WallsColor { get; }

        public Color RoofColor { get; }

        public Size Height { get; }

        public Counter LevelCount { get; }

        public Building(
            GuidValueObject buildingId,
            LongName universityName,
            LongName campusName,
            MediumName siteName,
            ShortName buildingAcronym,
            LongName buildingName,
            Coordinate centerX,
            Coordinate centerY,
            Size length,
            Size width,
            Angle rotation,
            Color? wallsColor = null,
            Color? roofColor = null,
            Size? height = null,
            Counter? levelCount = null)
        {
            BuildingId = buildingId;
            UniversityName = universityName;
            CampusName = campusName;
            SiteName = siteName;
            BuildingAcronym = buildingAcronym;
            BuildingName = buildingName;
            CenterX = centerX;
            CenterY = centerY;
            Length = length;
            Width = width;
            Rotation = rotation;
            WallsColor = wallsColor ?? Color.Create("#FFFFFF");
            RoofColor = roofColor ?? Color.Create("#FFFFFF");
            Height = height ?? Size.Create(3);
            LevelCount = levelCount ?? Counter.Create(0);
        }
    }
}
