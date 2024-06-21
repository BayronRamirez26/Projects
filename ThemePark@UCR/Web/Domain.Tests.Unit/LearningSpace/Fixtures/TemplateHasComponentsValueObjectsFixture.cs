using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Fixtures
{
    public class TemplateHasComponentsFixture
    {
        // Input Battery for WithValidParameters
        private GuidWrapper inputTemplateId = GuidWrapper.Create(Guid.NewGuid());
        private const string inputComponentTypeName = "ComponentType";
        private GuidWrapper inputTemplate = GuidWrapper.Create(Guid.NewGuid());
        private const double inputSizeX = 100.0;
        private const double inputSizeY = 200.0;
        private const double inputPositionX = 1;
        private const double inputPositionY = 2;
        private const double inputPositionZ = 3;
        private const double inputRotationX = 45;
        private const double inputRotationY = 90;

        public enum actualContext
        {
            WithValidParameters,
            WithNullComponentType,
            WithNullTemplate,
            WithDefaultGuid,
            WithBoundaryValues,
            WithZeroesValues,
            WithNegativeValues,
            WithBigValues
        }

        public GuidWrapper Id { get; private set; }
        public MediumName ComponentType { get; private set; }
        public GuidWrapper Template { get; private set; }
        public DoubleWrapper SizeX { get; private set; }
        public DoubleWrapper SizeY { get; private set; }
        public DoubleWrapper PositionX { get; private set; }
        public DoubleWrapper PositionY { get; private set; }
        public DoubleWrapper PositionZ { get; private set; }
        public DoubleWrapper RotationX { get; private set; }
        public DoubleWrapper RotationY { get; private set; }

        public TemplateHasComponentsFixture()
        {
            Id = inputTemplateId;
            ComponentType = new MediumName(inputComponentTypeName);
            Template = inputTemplate;
            SizeX = new DoubleWrapper(inputSizeX);
            SizeY = new DoubleWrapper(inputSizeY);
            PositionX = new DoubleWrapper(inputPositionX);
            PositionY = new DoubleWrapper(inputPositionY);
            PositionZ = new DoubleWrapper(inputPositionZ);
            RotationX = new DoubleWrapper(inputRotationX);
            RotationY = new DoubleWrapper(inputRotationY);
        }

        public void ChangeContext(actualContext inputContext)
        {
            switch (inputContext)
            {
                case actualContext.WithValidParameters:
                    Id = inputTemplateId;
                    ComponentType = new MediumName(inputComponentTypeName);
                    Template = inputTemplate;
                    SizeX = new DoubleWrapper(inputSizeX);
                    SizeY = new DoubleWrapper(inputSizeY);
                    PositionX = new DoubleWrapper(inputPositionX);
                    PositionY = new DoubleWrapper(inputPositionY);
                    PositionZ = new DoubleWrapper(inputPositionZ);
                    RotationX = new DoubleWrapper(inputRotationX);
                    RotationY = new DoubleWrapper(inputRotationY);
                    break;

                case actualContext.WithNullComponentType:
                    Id = inputTemplateId;
                    ComponentType = null;
                    Template = inputTemplate;
                    SizeX = new DoubleWrapper(inputSizeX);
                    SizeY = new DoubleWrapper(inputSizeY);
                    PositionX = new DoubleWrapper(inputPositionX);
                    PositionY = new DoubleWrapper(inputPositionY);
                    PositionZ = new DoubleWrapper(inputPositionZ);
                    RotationX = new DoubleWrapper(inputRotationX);
                    RotationY = new DoubleWrapper(inputRotationY);
                    break;

                case actualContext.WithNullTemplate:
                    Id = inputTemplateId;
                    ComponentType = new MediumName(inputComponentTypeName);
                    Template = inputTemplate;
                    SizeX = new DoubleWrapper(inputSizeX);
                    SizeY = new DoubleWrapper(inputSizeY);
                    PositionX = new DoubleWrapper(inputPositionX);
                    PositionY = new DoubleWrapper(inputPositionY);
                    PositionZ = new DoubleWrapper(inputPositionZ);
                    RotationX = new DoubleWrapper(inputRotationX);
                    RotationY = new DoubleWrapper(inputRotationY);
                    Template = GuidWrapper.Create(Guid.Empty);  // Assuming null template means empty Guid in this context
                    break;

                case actualContext.WithDefaultGuid:
                    Id = inputTemplateId;
                    ComponentType = new MediumName(inputComponentTypeName);
                    Template = inputTemplate;
                    SizeX = new DoubleWrapper(inputSizeX);
                    SizeY = new DoubleWrapper(inputSizeY);
                    PositionX = new DoubleWrapper(inputPositionX);
                    PositionY = new DoubleWrapper(inputPositionY);
                    PositionZ = new DoubleWrapper(inputPositionZ);
                    RotationX = new DoubleWrapper(inputRotationX);
                    RotationY = new DoubleWrapper(inputRotationY);
                    Id = GuidWrapper.Create(Guid.Empty);  
                    break;

                case actualContext.WithBoundaryValues:
                    Id = GuidWrapper.Create(Guid.NewGuid());
                    ComponentType = new MediumName("ComponentType");
                    Template = GuidWrapper.Create(Guid.NewGuid());
                    SizeX = new DoubleWrapper(double.MaxValue);
                    SizeY = new DoubleWrapper(double.MinValue);
                    PositionX = new DoubleWrapper(double.PositiveInfinity);
                    PositionY = new DoubleWrapper(double.NegativeInfinity);
                    PositionZ = new DoubleWrapper(double.NaN);
                    RotationX = new DoubleWrapper(360.0);
                    RotationY = new DoubleWrapper(-360.0);
                    break;

                case actualContext.WithZeroesValues:
                    Id = GuidWrapper.Create(Guid.NewGuid());
                    ComponentType = new MediumName("ComponentType");
                    Template = GuidWrapper.Create(Guid.NewGuid());
                    SizeX = new DoubleWrapper(0.0);
                    SizeY = new DoubleWrapper(0.0);
                    PositionX = new DoubleWrapper(0.0);
                    PositionY = new DoubleWrapper(0.0);
                    PositionZ = new DoubleWrapper(0.0);
                    RotationX = new DoubleWrapper(0.0);
                    RotationY = new DoubleWrapper(0.0);
                    break;

                case actualContext.WithNegativeValues:
                    Id = GuidWrapper.Create(Guid.NewGuid());
                    ComponentType = new MediumName("ComponentType");
                    Template = GuidWrapper.Create(Guid.NewGuid());
                    SizeX = new DoubleWrapper(-10.0);
                    SizeY = new DoubleWrapper(-20.0);
                    PositionX = new DoubleWrapper(-30.0);
                    PositionY = new DoubleWrapper(-40.0);
                    PositionZ = new DoubleWrapper(-50.0);
                    RotationX = new DoubleWrapper(-60.0);
                    RotationY = new DoubleWrapper(-70.0);
                    break;

                case actualContext.WithBigValues:
                    Id = GuidWrapper.Create(Guid.NewGuid());
                    ComponentType = new MediumName("ComponentType");
                    Template = GuidWrapper.Create(Guid.NewGuid());
                    SizeX = new DoubleWrapper(1000.0);
                    SizeY = new DoubleWrapper(2000.0);
                    PositionX = new DoubleWrapper(3000.0);
                    PositionY = new DoubleWrapper(4000.0);
                    PositionZ = new DoubleWrapper(5000.0);
                    RotationX = new DoubleWrapper(6000.0);
                    RotationY = new DoubleWrapper(7000.0);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(inputContext), inputContext, null);
            }
        }

        
    }
}
