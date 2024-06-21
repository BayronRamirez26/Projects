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

public class SqlAIAssistantRepositoryRepositoryTests : IClassFixture<SqlAIAssistantRespositoryFixture>
{
    private readonly SqlAIAssistantRespositoryFixture _fixture;
    private readonly ILogger<SqlAIAssistantRepository> _logger;
    public SqlAIAssistantRepositoryRepositoryTests(SqlAIAssistantRespositoryFixture fixture)
    {
        _fixture = fixture;
        
    }

    [Fact]
    public async Task GetAIAssistantsReturnAIAssistants()
    {
        // Arrange
        var aIAssistants = _fixture.aIAssistants;
        var aIAssistantsDBMock = aIAssistants.BuildMock().BuildMockDbSet();

        var mockLogger = new Mock<ILogger<SqlAIAssistantRepository>>();
        
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(dbContext => dbContext.AIAssistants)
            .Returns(aIAssistantsDBMock.Object);

        var repository = new SqlAIAssistantRepository(mockDbContext.Object);
        // Act
        var results = await repository.GetAIAssistantAsync();
         
        // Assert
        results.Should().BeEquivalentTo(aIAssistants);
    }

    [Fact]
    public async Task GetLearningSpaceAsync_WhenNoLearningSpaces_ShouldReturnEmptyList()
    {

        // Arrange
        var aIAssistants = new List<AIAssistant>().AsQueryable().BuildMockDbSet();
        var mockLogger = new Mock<ILogger<SqlAIAssistantRepository>>();

        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(dbContext => dbContext.AIAssistants)
            .Returns(aIAssistants.Object);

        var repository = new SqlAIAssistantRepository(mockDbContext.Object);
        // Act
        var results = await repository.GetAIAssistantAsync();

        // Assert
        results.Should().BeEmpty();
    }


    [Fact]
    public async Task CreateAIAssistantReturnTrue()
    {
        // Arrange

        var aIAssistantsDBMock = _fixture.aIAssistants.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();

        var mockLogger = new Mock<ILogger<SqlAIAssistantRepository>>();
        
        mockDbContext
            .Setup(dbContext => dbContext.AIAssistants)
            .Returns(aIAssistantsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);
        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        
        var repository = new SqlAIAssistantRepository(mockDbContext.Object);

        var result = await repository.CreateAIAssistantAsync(_fixture.ValidAIAssistant);

        // Assert
        result.Should().BeTrue();

    }

    [Fact]
    public async Task CreateAIAssistantWhenAIAssistantNullReturnFalse()
    {
        // Arrange

        var aIAssistantsDBMock = _fixture.aIAssistants.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlAIAssistantRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.AIAssistants)
            .Returns(aIAssistantsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlAIAssistantRepository(mockDbContext.Object);

        // Act
        var result = await repository.CreateAIAssistantAsync(_fixture.InvalidAIAssistant);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ModifyLearningSpaceValidAIAssistantReturnTrue()
    {
        // Arrange

        var aIAssistantsDBMock = _fixture.aIAssistants.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlAIAssistantRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.AIAssistants)
            .Returns(aIAssistantsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlAIAssistantRepository(mockDbContext.Object);

        // Act
        var result = await repository.ModifyAIAssistantAsync(_fixture.aIAssistants.First());

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ModifyAIAssistantInvalidAIAssistantReturnFalse()
    {
        // Arrange

        var aIAssistantsDBMock = _fixture.aIAssistants.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlAIAssistantRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.AIAssistants)
            .Returns(aIAssistantsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlAIAssistantRepository(mockDbContext.Object);

        // Act
        var result = await repository.ModifyAIAssistantAsync(_fixture.InvalidAIAssistant);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteInvalidAIAssistantReturnFalse()
    {
        // Arrange

        var aIAssistantsDBMock = _fixture.aIAssistants.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlAIAssistantRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.AIAssistants)
            .Returns(aIAssistantsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlAIAssistantRepository(mockDbContext.Object);

        // Act
        var result = await repository.DeleteAIAssistantAsync(_fixture.InvalidAIAssistant);

        // Assert
        result.Should().BeFalse();
    }

    public async Task DeleteValidAIAssistantReturnTrue()
    {
        // Arrange

        var aIAssistantsDBMock = _fixture.aIAssistants.BuildMock().BuildMockDbSet();
        var mockDbContext = new Mock<ApplicationDbContext>();
        var mockLogger = new Mock<ILogger<SqlAIAssistantRepository>>();

        mockDbContext
            .Setup(dbContext => dbContext.AIAssistants)
            .Returns(aIAssistantsDBMock.Object);

        var MockDbTransaction = new Mock<IDbContextTransaction>();
        var MockDbFacade = new Mock<DatabaseFacade>(mockDbContext.Object);

        mockDbContext
            .Setup(dbContext => dbContext.Database)
            .Returns(MockDbFacade.Object);
        MockDbFacade
            .Setup(db => db.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(MockDbTransaction.Object);

        var repository = new SqlAIAssistantRepository(mockDbContext.Object);

        // Act
        var result = await repository.DeleteAIAssistantAsync(_fixture.aIAssistants.First());

        // Assert
        result.Should().BeFalse();
    }

}
