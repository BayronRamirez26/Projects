using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities
{
    public class Whiteboard : LearningComponent 
    {
        public Whiteboard(LComponentID componentID, MediumName learningComponentName, Size sizeX, Size sizeY,
            Coordinate positionX, Coordinate positionY, Coordinate positionZ, Coordinate rotationX, Coordinate rotationY, GuidWrapper learningSpaceId) : base(learningComponentName, sizeX, sizeY, positionX, positionY, positionZ, rotationX, rotationY, learningSpaceId)
        {
            SetLearningComponentAssetId(componentID);
        }

        public Whiteboard(MediumName learningComponentName, Size sizeX, Size sizeY,
            Coordinate positionX, Coordinate positionY, Coordinate positionZ, Coordinate rotationX, Coordinate rotationY, GuidWrapper learningSpaceId) : base(learningComponentName, sizeX, sizeY, positionX, positionY, positionZ, rotationX, rotationY, learningSpaceId)
        {

        }
    

        internal Whiteboard():this (
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
       
    

    