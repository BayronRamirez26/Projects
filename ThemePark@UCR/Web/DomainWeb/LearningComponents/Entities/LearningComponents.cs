using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;


namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities
{
    public abstract class LearningComponent
    {
        public LearningComponent (MediumName learningComponentName, Size sizeX, Size sizeY,
            Coordinate positionX, Coordinate positionY, Coordinate positionZ, Coordinate rotationX, Coordinate rotationY, GuidWrapper learningSpaceId)
        {
            LearningComponentName = learningComponentName;
            SizeX = sizeX;
            SizeY = sizeY;
            PositionX = positionX;
            PositionY = positionY;
            PositionZ = positionZ;
            RotationX = rotationX;
            RotationY = rotationY;
            LearningSpaceId = learningSpaceId;
        }
        

        [Key]
        public int LearningComponentAssetId { get; private set; }
        public MediumName LearningComponentName { get; }
        public Size SizeX { get; }
        public Size SizeY { get; }
        public Coordinate PositionX { get;  }
        public Coordinate PositionY { get; }
        public Coordinate PositionZ { get; }
        public Coordinate RotationX { get; }
        public Coordinate RotationY { get; }
        public GuidWrapper LearningSpaceId { get;  }

        public void SetLearningComponentAssetId(LComponentID learningComponentID)
        {
            ArgumentNullException.ThrowIfNull(learningComponentID);

            LearningComponentAssetId = learningComponentID.Value;
        }

    }
}