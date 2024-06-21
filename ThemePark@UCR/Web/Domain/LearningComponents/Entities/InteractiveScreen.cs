using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities
{
    public class InteractiveScreen : LearningComponent
    {
        public InteractiveScreen(LComponentID componentID, MediumName learningComponentName, Size sizeX, Size sizeY,
            Coordinate positionX, Coordinate positionY, Coordinate positionZ, Coordinate rotationX, Coordinate rotationY, GuidWrapper learningSpaceId) : base(learningComponentName, sizeX, sizeY, positionX, positionY, positionZ, rotationX, rotationY, learningSpaceId)
        {
            SetLearningComponentAssetId(componentID);
        }

        public InteractiveScreen(MediumName learningComponentName, Size sizeX, Size sizeY,
            Coordinate positionX, Coordinate positionY, Coordinate positionZ, Coordinate rotationX, Coordinate rotationY, GuidWrapper learningSpaceId) : base(learningComponentName, sizeX, sizeY, positionX, positionY, positionZ, rotationX, rotationY, learningSpaceId)
        {
        }


        // Constructor sin parámetros para EF Core
        internal InteractiveScreen() : this(
            LComponentID.Create(0),
            MediumName.Create("Default"),
            Size.Create(0.0),
            Size.Create(0.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid()))
        {
        }
    }
}
       
    

    