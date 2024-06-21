using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningComponents.Fixtures
{
    public class LearningComponentFixture
    {
        private const int DefaultComponentIdValue = 1;
        private const string DefaultLearningComponentNameValue = "Default";
        private const double DefaultSizeValue = 0.0;
        private const double DefaultCoordinateValue = 0.0;
        private static readonly Guid DefaultGuidValue = Guid.Empty;

        public LComponentID ComponentID { get; private set; }
        public MediumName LearningComponentName { get; private set; }
        public Size SizeX { get; private set; } = Size.Create(0.0);
        public Size SizeY { get; private set; } =  Size.Create(0.0);
        public Coordinate PositionX { get; private set; } = Coordinate.Create(0);
        public Coordinate PositionY { get; private set; } = Coordinate.Create(0);
        public Coordinate PositionZ { get; private set; } = Coordinate.Create(0);
        public Coordinate RotationX { get; private set; } = Coordinate.Create(0);
        public Coordinate RotationY { get; private set; } = Coordinate.Create(0);
        public GuidWrapper LearningSpaceId { get; private set; } = GuidWrapper.Create(Guid.Empty);

        public LearningComponentFixture()
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            ComponentID = LComponentID.Create(DefaultComponentIdValue);
            LearningComponentName = MediumName.Create(DefaultLearningComponentNameValue);
            SizeX = Size.Create(DefaultSizeValue);
            SizeY = Size.Create(DefaultSizeValue);
            PositionX = Coordinate.Create(DefaultCoordinateValue);
            PositionY = Coordinate.Create(DefaultCoordinateValue);
            PositionZ = Coordinate.Create(DefaultCoordinateValue);
            RotationX = Coordinate.Create(DefaultCoordinateValue);
            RotationY = Coordinate.Create(DefaultCoordinateValue);
            LearningSpaceId = GuidWrapper.Create(DefaultGuidValue);
        }

        public enum Context
        {
            Default,
            SmallLearningComponent,
            InvalidSize,
            InvalidComponentID
        }

        public void ChangeContext(Context context)
        {
            switch (context)
            {
                case Context.Default:
                    SetDefaultValues();
                    break;
                case Context.SmallLearningComponent:
                    ComponentID = LComponentID.Create(2);
                    LearningComponentName = MediumName.Create("Default");
                    SizeX = Size.Create(50.0);
                    SizeY = Size.Create(30.0);
                    LearningSpaceId = GuidWrapper.Create(Guid.NewGuid());
                    break;
                case Context.InvalidSize:
                    ComponentID = LComponentID.Create(2);
                    LearningComponentName = MediumName.Create("Default");
                    SizeX = Size.Create(-50);
                    SizeY = Size.Create(-30);
                    LearningSpaceId = GuidWrapper.Create(Guid.NewGuid());
                    break;
                case Context.InvalidComponentID:
                    ComponentID = LComponentID.Create(-5);
                    LearningComponentName = MediumName.Create("Default");
                    SizeX = Size.Create(-50);
                    SizeY = Size.Create(-30);
                    LearningSpaceId = GuidWrapper.Create(Guid.NewGuid());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(context), context, null);
            }
        }

        public Projector CreateProjector()
        {
            return new Projector(
                ComponentID,
                LearningComponentName,
                SizeX,
                SizeY,
                PositionX,
                PositionY,
                PositionZ,
                RotationX,
                RotationY,
                LearningSpaceId);
        }

        public Whiteboard CreateWhiteboard()
        {
            return new Whiteboard(
                ComponentID,
                LearningComponentName,
                SizeX,
                SizeY,
                PositionX,
                PositionY,
                PositionZ,
                RotationX,
                RotationY,
                LearningSpaceId);
        }

        public InteractiveScreen CreateInteractiveScreen()
        {
            return new InteractiveScreen(
                ComponentID,
                LearningComponentName,
                SizeX,
                SizeY,
                PositionX,
                PositionY,
                PositionZ,
                RotationX,
                RotationY,
                LearningSpaceId);
        }

        public AIAssistant CreateAIAssistant()
        {
            return new AIAssistant(
                ComponentID,
                LearningComponentName,
                SizeX,
                SizeY,
                PositionX,
                PositionY,
                PositionZ,
                RotationX,
                RotationY,
                LearningSpaceId);
        }
    }
}

