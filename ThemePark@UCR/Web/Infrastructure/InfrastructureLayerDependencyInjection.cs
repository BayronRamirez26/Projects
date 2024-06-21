using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;
//using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.Repositories;
// Here add all repositories to use od domain layer and infrastructure layer
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure;

/// <summary>
/// Injects dependencies into Api Client
/// </summary>
public static class InfrastructureLayerDependencyInjection
{
    /// <summary>
    /// List of tuples containing repository interface types and their corresponding repository implementation types.
    /// </summary>
    private static readonly List<(Type, Type)> _infraLayerRepositories = new()
    {
        (typeof(ISiteRepository), typeof(SqlSiteRepository)),
        (typeof(IBuildingRepository), typeof(SqlBuildingRepository)),
        (typeof(ILevelRepository), typeof(SqlLevelRepository)),
        (typeof(IBOTemplateRepository), typeof(SqlBOTemplateRepository)),
        (typeof(IBuildingObjectRepository), typeof(SqlBuildingObjectRepository)),
        (typeof(ILearningSpaceRepository), typeof(SqlLearningSpaceRepository)),
        (typeof(ILearningSpaceRepository), typeof(SqlLearningSpaceRepository)),
        (typeof(ILearningSpaceCascadeRepository), typeof(SqlLearningSpaceCascadeRepository)),
        
        (typeof(IlearningSpaceTypeRepository), typeof(SqlLsTypeRepository)),
        (typeof(IAccessPointRepository), typeof(SqlAccesPointRepository)),

        (typeof(IWhiteboardRepository), typeof(SqlWhiteboardRepository)),
        (typeof(IProjectorRepository), typeof(SqlProjectorRepository)),
        (typeof(IInteractiveScreenRepository), typeof(SqlInteractiveScreen)),
        (typeof(IAIAssistantRepository), typeof(SqlAIAssistantRepository)),
        (typeof(ITemplateRepository), typeof(SqlTemplatesRepository)),

        (typeof(IUserRepository), typeof(SqlUserRepository)),
        (typeof(IPersonRepository), typeof(SqlPersonsRepository)),
        (typeof(IRoleRepository), typeof(SqlRoleRepository)),
        (typeof(IPermissionRepository), typeof(SqlPermissionRepository)),
        (typeof(IStudentRepository), typeof(SqlStudentRepository)),
        (typeof(IProfessorRepository), typeof(SqlProfessorRepository)),
    };

    /// <summary>
    /// Configures infrastructure API client layer services in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to which the services will be added.</param>
    /// <param name="configuration">The configuration used for configuring the API client.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddInfrastructureLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        addScopedRepositories(services);
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }

    /// <summary>
    /// Register all repositories with a foreach loop in the _infraApiClientLayerRepositories list
    /// </summary>
    /// <param name="services">All services</param>
    private static void addScopedRepositories(IServiceCollection services)
    {
        foreach (var repository in _infraLayerRepositories)
        {
            services.AddScoped(repository.Item1, repository.Item2);
        }

        /*services.AddScoped<ILearningSpaceRepository, SqlLearningSpaceRepository>();
        services.AddScoped<IClassroomRepository, SqlClassroomRepository>();*/
    }
}
