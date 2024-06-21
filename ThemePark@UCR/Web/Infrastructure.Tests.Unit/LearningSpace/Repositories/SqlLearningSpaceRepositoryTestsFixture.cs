using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningSpace.Repositories
{
    public class SqlLearningSpaceRepositoryTestsFixture
    {
        public GuidWrapper invalidId { get; private set; }
        public LearningSpaces LearningSpacesValid { get; private set; }

        public IEnumerable<LearningSpaces> LearningSpacesList { get; private set; }


        public SqlLearningSpaceRepositoryTestsFixture()
        {
            invalidId = GuidWrapper.Create(Guid.Empty);
            LearningSpacesValid = new LearningSpaces(
                 GuidWrapper.Create(Guid.NewGuid()),
                 ShortName.Create("Space 1"),
                 DoubleWrapper.Create(10.0), // sizeX
                 DoubleWrapper.Create(10.0), // sizeY
                 DoubleWrapper.Create(10.0), // sizeZ
                 MediumName.Create("Floor Color 1"), // floor color
                 MediumName.Create("Ceiling Color 1"), // ceiling color
                 MediumName.Create("Walls Color 1"), // wall color
                 GuidWrapper.Create(Guid.NewGuid()),
                 GuidWrapper.Create(Guid.NewGuid())
             );


            LearningSpacesList = new List<LearningSpaces>
            {
                new LearningSpaces(
                    GuidWrapper.Create(Guid.NewGuid()),
                    ShortName.Create("Space 1"),
                    DoubleWrapper.Create(10.0), // sizeX
                    DoubleWrapper.Create(10.0), // sizeY
                    DoubleWrapper.Create(10.0), // sizeZ
                    MediumName.Create("Floor Color 1"), // floor color
                    MediumName.Create("Ceiling Color 1"), // ceiling color
                    MediumName.Create("Walls Color 1"), // wall color
                    GuidWrapper.Create(Guid.NewGuid()),
                    GuidWrapper.Create(Guid.NewGuid())
                ),
                new LearningSpaces(
                    GuidWrapper.Create(Guid.NewGuid()),
                    ShortName.Create("Space 2"),
                    DoubleWrapper.Create(10.0), // sizeX
                    DoubleWrapper.Create(10.0), // sizeY
                    DoubleWrapper.Create(10.0), // sizeZ
                    MediumName.Create("Floor Color 1"), // floor color
                    MediumName.Create("Ceiling Color 1"), // ceiling color
                    MediumName.Create("Walls Color 1"), // wall color
                    GuidWrapper.Create(Guid.NewGuid()),
                    GuidWrapper.Create(Guid.NewGuid())
                )
            };

        

        }
    

    }
}
