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

public class SqlWhiteboardRepositoryRepositoryTests : IClassFixture<SqlWhiteboardRepositoryFixture>
{
    private readonly SqlWhiteboardRepositoryFixture _fixture;
    public SqlWhiteboardRepositoryRepositoryTests(SqlWhiteboardRepositoryFixture fixture)
    {
        _fixture = fixture;
        
    }

    [Fact]
    public async Task CreateWhiteboardWhenWhiteboardNullReturnFalse()
    {
        // Arrange

        var whiteboardsDBMock = _fixture.whiteboards.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlWhiteboardRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.Whiteboard)
            .Returns(whiteboardsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlWhiteboardRepository(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.CreateWhiteboardAsync(_fixture.InvalidWhiteboard);

        // Assert
        result.Should().BeFalse();
    }
   
    [Fact]
    public async Task ModifyWhiteboardInvalidWhiteboardReturnFalse()
    {
        // Arrange

        var whiteboardsDBMock = _fixture.whiteboards.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlWhiteboardRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.Whiteboard)
            .Returns(whiteboardsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlWhiteboardRepository(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.ModifyWhiteboardAsync(_fixture.InvalidWhiteboard);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteInvalidWhiteboardReturnFalse()
    {
        // Arrange

        var whiteboardsDBMock = _fixture.whiteboards.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlWhiteboardRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.Whiteboard)
            .Returns(whiteboardsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlWhiteboardRepository(mockDbContext.Object, mockLogger.Object);

        // Act
        var result = await repository.DeleteWhiteboardAsync(_fixture.InvalidWhiteboard);

        // Assert
        result.Should().BeFalse();
    }
}

