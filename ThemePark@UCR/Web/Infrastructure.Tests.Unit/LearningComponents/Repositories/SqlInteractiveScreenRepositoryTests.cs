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

public class SqlInteractiveScreenRepositoryTests : IClassFixture<SqlInteractiveScreenRepositoryFixture>
{
    private readonly SqlInteractiveScreenRepositoryFixture _fixture;
    public SqlInteractiveScreenRepositoryTests(SqlInteractiveScreenRepositoryFixture fixture)
    {
        _fixture = fixture;
        
    }

    [Fact]
    public async Task CreateInteractiveScreenWhenInteractiveScreenNullReturnFalse()
    {
        // Arrange

        var interactiveScreensDBMock = _fixture.interactiveScreens.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlInteractiveScreen>>();

        mockDbContext
            .Setup(dbContext => dbContext.InteractiveScreens)
            .Returns(interactiveScreensDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlInteractiveScreen(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.CreateInteractiveScreenAsync(_fixture.InvalidInteractiveScreen);

        // Assert
        result.Should().BeFalse();
    }
   
    [Fact]
    public async Task ModifyInteractiveScreenInvalidInteractiveScreenReturnFalse()
    {
        // Arrange

        var interactiveScreensDBMock = _fixture.interactiveScreens.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlInteractiveScreen>>();

        mockDbContext
            .Setup(dbContext => dbContext.InteractiveScreens)
            .Returns(interactiveScreensDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlInteractiveScreen(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.ModifyInteractiveScreenAsync(_fixture.InvalidInteractiveScreen);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteInvalidInteractiveScreenReturnFalse()
    {
        // Arrange

        var interactiveScreensDBMock = _fixture.interactiveScreens.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlInteractiveScreen>>();

        mockDbContext
            .Setup(dbContext => dbContext.InteractiveScreens)
            .Returns(interactiveScreensDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlInteractiveScreen(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.DeleteInteractiveScreenAsync(_fixture.InvalidInteractiveScreen);

        // Assert
        result.Should().BeFalse();
    }
}

