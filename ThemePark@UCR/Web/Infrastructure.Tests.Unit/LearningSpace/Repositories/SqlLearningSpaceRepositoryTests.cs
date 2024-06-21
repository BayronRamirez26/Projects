using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories;
using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using MockQueryable.Moq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningSpace.Repositories
{
    public class SqlLearningSpaceRepositoryTests : IClassFixture<SqlLearningSpaceRepositoryTestsFixture>
    {
        private readonly SqlLearningSpaceRepositoryTestsFixture _fixture;

        public SqlLearningSpaceRepositoryTests(SqlLearningSpaceRepositoryTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetLearningSpaceAsync_ShouldReturnAllLearningSpaces()
        {
            // Arrange
            var learningSpaceList = _fixture.LearningSpacesList;
            var learningSpaceDBSetMock = learningSpaceList.BuildMock().BuildMockDbSet();

            var mockDbContext = new Mock<ApplicationDbContext>();
            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDBSetMock.Object);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);
            // Act
            var results = await repository.GetLearningSpaceAsync();

            // Assert
            results.Should().BeEquivalentTo(learningSpaceList);
        }

        [Fact]
        public async Task GetLearningSpaceAsync_WhenNoLearningSpaces_ShouldReturnEmptyList()
        {
            // Arrange
            var emptyList = new List<LearningSpaces>().AsQueryable().BuildMockDbSet();
            var mockDbContext = new Mock<ApplicationDbContext>();
            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(emptyList.Object);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var results = await repository.GetLearningSpaceAsync();

            // Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public async Task GetLearningSpaceFromIdAsync_WhenIdIsInvalid_ShouldReturnNull()
        {
            // Arrange
            var learningSpaceDbSetMock = _fixture.LearningSpacesList.BuildMock().BuildMockDbSet();
            var mockDbContext = new Mock<ApplicationDbContext>();
            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDbSetMock.Object);

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces.FindAsync(_fixture.invalidId))
                .ReturnsAsync((LearningSpaces)null);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var result = await repository.GetLearningSpaceFromIdAsync(_fixture.invalidId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task CreateLearningSpace_WithCorrectLearningSpace_ShouldReturnTrue()
        {
            // Arrange
            var mockDbContext = new Mock<ApplicationDbContext>();
            var learningSpaceDbSetMock = _fixture.LearningSpacesList.BuildMock().BuildMockDbSet();

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDbSetMock.Object);

            var mockDbTransaction = new Mock<IDbContextTransaction>();
            var mockDatabaseFacade = new Mock<DatabaseFacade>(mockDbContext.Object);
            mockDbContext
                .Setup(dbContext => dbContext.Database)
                .Returns(mockDatabaseFacade.Object);
            mockDatabaseFacade
              .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockDbTransaction.Object);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var result = await repository.CreateLearningSpaceAsync(_fixture.LearningSpacesValid);

            // Assert
            result.Should().BeTrue();

        }

        [Fact]
        public async Task CreateLearningSpaceAsync_WhenLearningSpaceIsNull_ShouldReturnTrue()
        {
            // Arrange
            var mockDbContext = new Mock<ApplicationDbContext>();
            var learningSpaceDbSetMock = _fixture.LearningSpacesList.BuildMock().BuildMockDbSet();

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDbSetMock.Object);

            var mockDbTransaction = new Mock<IDbContextTransaction>();
            var mockDatabaseFacade = new Mock<DatabaseFacade>(mockDbContext.Object);
            mockDbContext
                .Setup(dbContext => dbContext.Database)
                .Returns(mockDatabaseFacade.Object);
            mockDatabaseFacade
              .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockDbTransaction.Object);


            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var result = await repository.CreateLearningSpaceAsync(null);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task ModifyLearningSpaceAsync_WithValidLearningSpace_ShouldReturnTrue()
        {
            // Arrange
            var mockDbContext = new Mock<ApplicationDbContext>();
            var learningSpaceDbSetMock = _fixture.LearningSpacesList.BuildMock().BuildMockDbSet();

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDbSetMock.Object);

            var mockDbTransaction = new Mock<IDbContextTransaction>();
            var mockDatabaseFacade = new Mock<DatabaseFacade>(mockDbContext.Object);
            mockDbContext
                .Setup(dbContext => dbContext.Database)
                .Returns(mockDatabaseFacade.Object);
            mockDatabaseFacade
              .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockDbTransaction.Object);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var result = await repository.ModifyLearningSpaceAsync(_fixture.LearningSpacesList.First());

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task ModifyLearningSpaceAsync_WhenLearningSpaceIsNull_ShouldReturnTrue()
        {
            // Arrange
            var mockDbContext = new Mock<ApplicationDbContext>();
            var learningSpaceDbSetMock = _fixture.LearningSpacesList.BuildMock().BuildMockDbSet();

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDbSetMock.Object);

            var mockDbTransaction = new Mock<IDbContextTransaction>();
            var mockDatabaseFacade = new Mock<DatabaseFacade>(mockDbContext.Object);
            mockDbContext
                .Setup(dbContext => dbContext.Database)
                .Returns(mockDatabaseFacade.Object);
            mockDatabaseFacade
              .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockDbTransaction.Object);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var result = await repository.ModifyLearningSpaceAsync(null);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task ModifyLearningSpaceAsync_WhenLearningSpaceDoesNotExist_ShouldReturnTrue()
        {
            // Arrange
            var nonExistingSpace = _fixture.LearningSpacesValid;
            var mockDbContext = new Mock<ApplicationDbContext>();
            var learningSpaceDbSetMock = _fixture.LearningSpacesList.BuildMock().BuildMockDbSet();

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDbSetMock.Object);

            var mockDbTransaction = new Mock<IDbContextTransaction>();
            var mockDatabaseFacade = new Mock<DatabaseFacade>(mockDbContext.Object);
            mockDbContext
                .Setup(dbContext => dbContext.Database)
                .Returns(mockDatabaseFacade.Object);
            mockDatabaseFacade
              .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockDbTransaction.Object);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var result = await repository.ModifyLearningSpaceAsync(nonExistingSpace);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteLearningSpaceAsync_WhenIdIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var mockDbContext = new Mock<ApplicationDbContext>();
            var learningSpaceDbSetMock = _fixture.LearningSpacesList.BuildMock().BuildMockDbSet();

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDbSetMock.Object);

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces.FindAsync(_fixture.invalidId))
                .ReturnsAsync((LearningSpaces)null);

            var mockDbTransaction = new Mock<IDbContextTransaction>();
            var mockDatabaseFacade = new Mock<DatabaseFacade>(mockDbContext.Object);
            mockDbContext
                .Setup(dbContext => dbContext.Database)
                .Returns(mockDatabaseFacade.Object);
            mockDatabaseFacade
              .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockDbTransaction.Object);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var result = await repository.DeleteLearningSpaceAsync(_fixture.invalidId);

            // Assert
            result.Should().BeFalse();
            learningSpaceDbSetMock.Verify(dbSet => dbSet.Remove(It.IsAny<LearningSpaces>()), Times.Never);
            mockDbContext.Verify(dbContext => dbContext.SaveChangesAsync(default), Times.Never);
        }

        [Fact]
        public async Task DeleteLearningSpaceAsync_WhenLearningSpaceDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var nonExistingSpace = _fixture.LearningSpacesValid;
            var mockDbContext = new Mock<ApplicationDbContext>();
            var learningSpaceDbSetMock = _fixture.LearningSpacesList.BuildMock().BuildMockDbSet();

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces)
                .Returns(learningSpaceDbSetMock.Object);

            mockDbContext
                .Setup(dbContext => dbContext.LearningSpaces.FindAsync(nonExistingSpace.LearningSpaceId))
                .ReturnsAsync((LearningSpaces)null);

            var mockDbTransaction = new Mock<IDbContextTransaction>();
            var mockDatabaseFacade = new Mock<DatabaseFacade>(mockDbContext.Object);
            mockDbContext
                .Setup(dbContext => dbContext.Database)
                .Returns(mockDatabaseFacade.Object);
            mockDatabaseFacade
              .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockDbTransaction.Object);

            var repository = new SqlLearningSpaceRepository(mockDbContext.Object);

            // Act
            var result = await repository.DeleteLearningSpaceAsync(nonExistingSpace.LearningSpaceId);

            // Assert
            result.Should().BeFalse();
            learningSpaceDbSetMock.Verify(dbSet => dbSet.Remove(It.IsAny<LearningSpaces>()), Times.Never);
            mockDbContext.Verify(dbContext => dbContext.SaveChangesAsync(default), Times.Never);
        }
    }
}
