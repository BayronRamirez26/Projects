using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Fixtures
{
    public class LSTypeValueObjectFixture
    {
        private Guid inputLSTypeId = Guid.NewGuid();
        private const string inputLSTypeName = "Valid Name";

        public enum ActualContext
        {
            WithValidParameters,
            WithNullId,
            WithNullName,
            WithEmptyId,
            WithEmptyStringName,
        }

        public GuidWrapper Id { get; private set; }
        public MediumName Name { get; private set; }

        public LSTypeValueObjectFixture()
        {
            Id = GuidWrapper.Create(inputLSTypeId);
            Name = MediumName.Create(inputLSTypeName);
        }

        public void ChangeContext(ActualContext inputContext)
        {
            switch (inputContext)
            {
                case ActualContext.WithValidParameters:
                    Id = GuidWrapper.Create(inputLSTypeId);
                    Name = MediumName.Create(inputLSTypeName);
                    break;
                case ActualContext.WithNullId:
                    Id = null;
                    Name = MediumName.Create(inputLSTypeName);
                    break;
                case ActualContext.WithNullName:
                    Id = GuidWrapper.Create(inputLSTypeId);
                    Name = null;
                    break;
                case ActualContext.WithEmptyId:
                    Id = GuidWrapper.Create(Guid.Empty);
                    Name = MediumName.Create(inputLSTypeName);
                    break;
                case ActualContext.WithEmptyStringName:
                    Id = GuidWrapper.Create(inputLSTypeId);
                    Name = MediumName.Create(string.Empty);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputContext), inputContext, null);
            }
        }
    }
}
