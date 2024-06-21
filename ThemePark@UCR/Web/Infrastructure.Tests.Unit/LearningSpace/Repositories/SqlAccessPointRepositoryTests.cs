using FluentAssertions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MockQueryable.Moq;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningSpace.Repositories
{
    public class SqlAccessPointRepositoryTests : IClassFixture<SqlAccessPointRepositoryTestsFixture>
    {

        private readonly SqlAccessPointRepositoryTestsFixture _fixture;

        public SqlAccessPointRepositoryTests(SqlAccessPointRepositoryTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CreateAccessPointAsync_ShouldReturnTrue_WhenAccessPointIsAdded()
        {
            // Arrange
            var newAccessPoint = _fixture.AccessPointValid;
            var accessPointDbSetMock = _fixture.listAccessPoint.BuildMock().BuildMockDbSet();

            var mockDbContext = new Mock<ApplicationDbContext>();
            mockDbContext
                .Setup(dbContext => dbContext.AccessPoints)
                .Returns(accessPointDbSetMock.Object);

            var mockDbTransaction = new Mock<IDbContextTransaction>();
            var mockDatabaseFacade = new Mock<DatabaseFacade>(mockDbContext.Object);
            mockDbContext
                .Setup(dbContext => dbContext.Database)
                .Returns(mockDatabaseFacade.Object);
            mockDatabaseFacade
              .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockDbTransaction.Object);

            var repository = new SqlAccesPointRepository(mockDbContext.Object);

            // Act
            var result = await repository.CreateAccessPointAsync(newAccessPoint);

            // Assert
            result.Should().BeTrue();
            mockDbContext.Verify(dbContext => dbContext.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task GetAccessPointAsync_ShouldReturnAllAccessPoints()
        {
            // Arrange
            var accessPointList = _fixture.listAccessPoint;
            var accessPointDbSetMock = accessPointList.BuildMock().BuildMockDbSet();

            var mockDbContext = new Mock<ApplicationDbContext>();
            mockDbContext
                .Setup(dbContext => dbContext.AccessPoints)
                .Returns(accessPointDbSetMock.Object);

            var repository = new SqlAccesPointRepository(mockDbContext.Object);

            // Act
            var results = await repository.GetAccessPointAsync();

            // Assert
            results.Should().BeEquivalentTo(accessPointList);
        }

        [Fact]
        public async Task ModifyAccessPointAsync_ShouldReturnTrue_WhenAccessPointIsUpdated()
        {
            // Arrange
            var existingAccessPoint = _fixture.listAccessPoint.First();

            var accessPointDbSetMock = _fixture.listAccessPoint.BuildMock().BuildMockDbSet();
            var mockDbContext = new Mock<ApplicationDbContext>();
            mockDbContext
                .Setup(dbContext => dbContext.AccessPoints)
                .Returns(accessPointDbSetMock.Object);

            var repository = new SqlAccesPointRepository(mockDbContext.Object);

            // Act
            var result = await repository.ModifyAccessPointAsync(existingAccessPoint);

            // Assert
            result.Should().BeTrue();
            accessPointDbSetMock.Verify(dbSet => dbSet.Update(existingAccessPoint), Times.Once);
            mockDbContext.Verify(dbContext => dbContext.SaveChangesAsync(default), Times.Once);
        }

        
    }
}
