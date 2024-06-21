using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Fixtures
{
    public class TemplateValueObjectFixture
    {
        // Default values for WithValidParameters context
        private Guid id = Guid.NewGuid();
        private string templateName = "Test Template";
        private double sizeX = 100.0;
        private double sizeY = 200.0;
        private double sizeZ = 300.0;
        private string floorColor = "Red";
        private string ceilingColor = "Blue";
        private string wallsColor = "Green";
        private Guid type = Guid.NewGuid();

        public enum actualContext
        {
            WithValidParameters,
            WithNullTemplateName,
            WithNullId,
            WithNullType,
            WithBoundaryCoordinateZeroValue,
            WithBoundaryCoordinatesNegative,
            WithMaxValues,
            WithPositiveInfinity,
            WithNegativeInfinity,
            WithNaN,
            WithExtremeSizeValues,
            WithNullName,
            WithNullFloorColor,
            WithNullCeilingColor,
            WithNullWallsColor,
            WithInvalidGuid
        };

        public Guid Id { get; private set; }
        public MediumName TemplateName { get; private set; }
        public DoubleWrapper SizeX { get; private set; }
        public DoubleWrapper SizeY { get; private set; }
        public DoubleWrapper SizeZ { get; private set; }
        public MediumName FloorColor { get; private set; }
        public MediumName CeilingColor { get; private set; }
        public MediumName WallsColor { get; private set; }
        public Guid Type { get; private set; }

        public TemplateValueObjectFixture()
        {
            // Initialize with default valid parameters
            ChangeContext(actualContext.WithValidParameters);
        }

        public void ChangeContext(actualContext inputContext)
        {
            switch (inputContext)
            {
                case actualContext.WithValidParameters:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithNullTemplateName:
                    Id = id;
                    TemplateName = null; // Template name is null for this case
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithNullId:
                    Id = Guid.Empty; // Using empty Guid to represent null-like scenario for Guid
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithNullType:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = Guid.Empty; // Using empty Guid to represent null-like scenario for Type
                    break;

                case actualContext.WithBoundaryCoordinateZeroValue:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(0.0);
                    SizeY = new DoubleWrapper(0.0);
                    SizeZ = new DoubleWrapper(0.0);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithBoundaryCoordinatesNegative:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(-10.5);
                    SizeY = new DoubleWrapper(-20.5);
                    SizeZ = new DoubleWrapper(-30.5);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithMaxValues:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(double.MaxValue);
                    SizeY = new DoubleWrapper(double.MinValue);
                    SizeZ = new DoubleWrapper(0);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithPositiveInfinity:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(double.PositiveInfinity);
                    SizeY = new DoubleWrapper(double.PositiveInfinity);
                    SizeZ = new DoubleWrapper(double.PositiveInfinity);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithNegativeInfinity:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(double.NegativeInfinity);
                    SizeY = new DoubleWrapper(double.NegativeInfinity);
                    SizeZ = new DoubleWrapper(double.NegativeInfinity);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithNaN:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(double.NaN);
                    SizeY = new DoubleWrapper(double.NaN);
                    SizeZ = new DoubleWrapper(double.NaN);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;

                case actualContext.WithExtremeSizeValues:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(double.MaxValue * 2);
                    SizeY = new DoubleWrapper(double.MinValue * 2);
                    SizeZ = new DoubleWrapper(double.MaxValue * 3);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;
                case actualContext.WithNullName:
                    Id = id;
                    TemplateName = new MediumName(null);
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;
                case actualContext.WithNullFloorColor:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(null);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;
                case actualContext.WithNullCeilingColor:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(null);
                    WallsColor = new MediumName(wallsColor);
                    Type = type;
                    break;
                case actualContext.WithNullWallsColor:
                    Id = id;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(null);
                    Type = type;
                    break;
                case actualContext.WithInvalidGuid:
                    Id = Guid.Empty;
                    TemplateName = new MediumName(templateName);
                    SizeX = new DoubleWrapper(sizeX);
                    SizeY = new DoubleWrapper(sizeY);
                    SizeZ = new DoubleWrapper(sizeZ);
                    FloorColor = new MediumName(floorColor);
                    CeilingColor = new MediumName(ceilingColor);
                    WallsColor = new MediumName(wallsColor);
                    Type = Guid.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputContext), inputContext, null);
            }
        }
    }
}
