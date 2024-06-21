using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningSpace.Fixtures;

public class AccessPointValueObjectFixture
{
    // Default
    private Guid inputAccessPointId = (Guid.NewGuid());
    private Guid inputLearningSpaceId = (Guid.NewGuid());
    private Guid inputLevelId = (Guid.NewGuid());
    const double inputCoordX = 10.5;
    const double inputCoordY = 20.5;
    const double inputCoordZ = 30.5;
    const double inputRotationX = 45.0;
    const double inputRotationY = 60.0;

    public enum actualContext
    {
        WithValidParameters,
        WithNullAccessPointId,
        WithNullLearningSpaceId,
        WithNullLevelId,
        WithZeroCoordinateValues,
        WithNegativeCoordinateValues,
        WithMaxCoordinateValues,
        WithZeroRotationValues,
        WithNegativeRotationValues,
        WithMaxRotationValues,
        WithPositiveInfinityCoordinateValues,
        WithNegativeInfinityCoordinateValues,
        WithNanCoordinateValues,
        WithExtremeCoordinateValues,
        WithPositiveInfinityRotationValues,
        WithNegativeInfinityRotationValues,
        WithNanRotationValues,
        WithExtremeRotationValues
    };

    public GuidWrapper AccessPointId { get; private set;  } // Guid AccessPointId
    public GuidWrapper LearningSpaceId { get; private set; } // Guid LearningSpaceId
    public GuidWrapper LevelId { get; private set; } // Guid LevelId
    public double CoordX { get; private set; } // X coordenates
    public double CoordY { get; private set; } // Y coordenates
    public double CoordZ { get; private set; } // Z coordenates
    public double RotationX { get; private set; } // X rotation
    public double RotationY { get; private set; } // Y rotation

    public void ChangeContext(actualContext inputContext)
    {
        switch (inputContext)
        {
            case actualContext.WithValidParameters:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithNullAccessPointId:
                AccessPointId = null;
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY  =inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithNullLearningSpaceId:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = null;
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithNullLevelId:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = null;
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithZeroCoordinateValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = 0;
                CoordY = 0;
                CoordZ = 0;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithNegativeCoordinateValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = -10.5;
                CoordY = -20.5;
                CoordZ = -30.5;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithMaxCoordinateValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = double.MaxValue;
                CoordY = double.MinValue;
                CoordZ = 0;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithZeroRotationValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = 0;
                RotationY = 0;
                break;
            case actualContext.WithNegativeRotationValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = -45.0;
                RotationY = -60.0;
                break;
            case actualContext.WithMaxRotationValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = double.MaxValue;
                RotationY = double.MinValue;
                break;
            case actualContext.WithPositiveInfinityCoordinateValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = double.PositiveInfinity;
                CoordY =double.PositiveInfinity;
                CoordZ = double.PositiveInfinity;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithNegativeInfinityCoordinateValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = double.NegativeInfinity;
                CoordY = double.NegativeInfinity;
                CoordZ = double.NegativeInfinity;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithNanCoordinateValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = double.NaN;
                CoordY = double.NaN;
                CoordZ = double.NaN;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithExtremeCoordinateValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = double.MaxValue * 2;
                CoordY = double.MinValue * 2;
                CoordZ = double.MaxValue * -2;
                RotationX = inputRotationX;
                RotationY = inputRotationY;
                break;
            case actualContext.WithPositiveInfinityRotationValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = double.PositiveInfinity;
                RotationY = double.PositiveInfinity;
                break;
            case actualContext.WithNegativeInfinityRotationValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = double.NegativeInfinity;
                RotationY = double.NegativeInfinity;
                break;
            case actualContext.WithNanRotationValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = double.NaN;
                RotationY = double.NaN;
                break;
            case actualContext.WithExtremeRotationValues:
                AccessPointId = GuidWrapper.Create(inputAccessPointId);
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LevelId = GuidWrapper.Create(inputLevelId);
                CoordX = inputCoordX;
                CoordY = inputCoordY;
                CoordZ = inputCoordZ;
                RotationX = double.MaxValue * 2;
                RotationY = double.MinValue * 2;
                break;
        }
    }
}
