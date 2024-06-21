using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningSpace.Repositories
{
    public class SqlAccessPointRepositoryTestsFixture
    {
        public AccessPoint returnAccessPoint { get; private set; }

        public AccessPoint AccessPointValid { get; set; }
        public IEnumerable<AccessPoint> listAccessPoint { get; set; }

        public GuidWrapper AccessPointId { get; private set; }
        public enum actualContext
        {
            ValidInput,
            NullInput,
            WhenGivenNoEmptyList
        };

        public SqlAccessPointRepositoryTestsFixture()
        {

            AccessPointValid = new AccessPoint(
                GuidWrapper.Create(new Guid()),
                GuidWrapper.Create(new Guid()),
                GuidWrapper.Create(new Guid()),
                0.0, 0.0, 0.0, 0.0, 0.0);
            

            listAccessPoint = new List<AccessPoint>
            {
                new AccessPoint(
                    GuidWrapper.Create(Guid.NewGuid()),
                    GuidWrapper.Create(Guid.NewGuid()),
                    GuidWrapper.Create(Guid.NewGuid()),
                    0.0, 0.0, 0.0, 0.0, 0.0),
                new AccessPoint(
                    GuidWrapper.Create(Guid.NewGuid()),
                    GuidWrapper.Create(Guid.NewGuid()),
                    GuidWrapper.Create(Guid.NewGuid()),
                    0.0, 0.0, 0.0, 0.0, 0.0)

            };



        }
    }
}
