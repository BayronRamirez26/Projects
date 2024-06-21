namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Dtos;

public class LearningComponentDto
{

    public int LearningComponentAssetId { get; set; }
    public string LearningComponentName { get; set; }
    public double PositionX { get; set; } = 0.0;
    public double PositionY { get; set; } = 0.0;
    public double PositionZ { get; set; } = 0.0;

    public double SizeX { get; set; } = 0;
    public double SizeY { get; set; } = 0;

    public double RotationX { get; set; } = 0;
    public double RotationY { get; set; } = 0;

    public Guid LearningSpaceId { get; set; }

    public LearningComponentDto(int learningComponentId, string learningComponentName, double positionX, double positionY, double positionZ, double sizeX, double sizeY, double rotationX, double rotationY, Guid learningSpaceId)
    {
        this.LearningComponentAssetId = learningComponentId;
        this.LearningComponentName = learningComponentName;
        PositionX = positionX;
        PositionY = positionY;
        PositionZ = positionZ;
        SizeX = sizeX;
        SizeY = sizeY;
        RotationX = rotationX;
        RotationY = rotationY;
        LearningSpaceId = learningSpaceId;

    }
    public LearningComponentDto(string learningComponentName, double positionX, double positionY, double positionZ, double sizeX, double sizeY, double rotationX, double rotationY, Guid learningSpaceId)
    {
        this.LearningComponentName = learningComponentName;
        PositionX = positionX;
        PositionY = positionY;
        PositionZ = positionZ;
        SizeX = sizeX;
        SizeY = sizeY;
        RotationX = rotationX;
        RotationY = rotationY;
        LearningSpaceId = learningSpaceId;
    }
    
}