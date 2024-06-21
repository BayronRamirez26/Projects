using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;


namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities
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
        internal LearningComponent() : this(
             MediumName.Create("Default"),
             Size.Create(0.0),
             Size.Create(0.0),
             Coordinate.Create(0.0),
             Coordinate.Create(0.0),
             Coordinate.Create(0.0),
             Coordinate.Create(0.0),
             Coordinate.Create(0.0),
             GuidWrapper.Create(Guid.NewGuid()))
        { }

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
            if (learningComponentID == null)
            {
                throw new ArgumentNullException("The provided LearningComponentID is null and cannot be used.");
            }

            LearningComponentAssetId = learningComponentID.Value;
        }

    }
}