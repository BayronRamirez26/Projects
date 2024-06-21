//*******************************************************************//
// Based on LearningSpacerServiceTest Test from "Los chayannes team" //
//*******************************************************************//
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningComponents.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningComponents.Repositories;

public class SqlProjectorRepositoryRepositoryTests : IClassFixture<SqlProjectorRepositoryFixture>
{
    private readonly SqlProjectorRepositoryFixture _fixture;
    public SqlProjectorRepositoryRepositoryTests(SqlProjectorRepositoryFixture fixture)
    {
        _fixture = fixture;
        
    }

    [Fact]
    public async Task CreateProjectorWhenProjectorNullReturnFalse()
    {
        // Arrange

        var projectorsDBMock = _fixture.projectors.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlProjectorRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.Projectors)
            .Returns(projectorsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlProjectorRepository(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.CreateProjectorAsync(_fixture.InvalidProjector);

        // Assert
        result.Should().BeFalse();
    }
   
    [Fact]
    public async Task ModifyProjectorInvalidProjectorReturnFalse()
    {
        // Arrange

        var projectorsDBMock = _fixture.projectors.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlProjectorRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.Projectors)
            .Returns(projectorsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlProjectorRepository(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.ModifyProjectorAsync(_fixture.InvalidProjector);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteInvalidProjectorReturnFalse()
    {
        // Arrange

        var projectorsDBMock = _fixture.projectors.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlProjectorRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.Projectors)
            .Returns(projectorsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlProjectorRepository(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.DeleteProjectorAsync(_fixture.InvalidProjector);

        // Assert
        result.Should().BeFalse();
    }
}

