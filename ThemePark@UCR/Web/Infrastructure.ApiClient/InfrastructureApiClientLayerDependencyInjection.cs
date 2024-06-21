using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Buildings.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Repositories;


namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;

/// <summary>
/// Injects dependencies into Api Client
/// </summary>
public static class InfrastructureApiClientLayerDependencyInjection
{
    /// <summary>
    /// List of tuples containing repository interface types and their corresponding repository implementation types.
    /// </summary>
    internal static readonly List<(Type, Type)> _infraApiClientLayerRepositories = new()
    {
        // Add all repositories here
        (typeof(ISiteRepository), typeof(ApiClientSiteRepository)),
        (typeof(IBuildingRepository), typeof(ApiClientBuildingRepository)),
        (typeof(ILevelRepository), typeof(ApiClientLevelRepository)),
        (typeof(IAccessPointRepository), typeof(ApiClientAccessPointRepository)),
        (typeof(ILearningSpaceRepository), typeof(ApiClientLearningSpaceRepository)),
        (typeof(ILearningSpaceCascadeRepository), typeof(ApiClientLearningSpaceCascadeRepository)),
        (typeof(IlearningSpaceTypeRepository), typeof(ApiClientLSTypeRepository)),

        // Learning Components repositories
        (typeof(IWhiteboardRepository),typeof(ApiClientWhiteboardRepositoy)),
        (typeof(IProjectorRepository),typeof(ApiClientProjectorRepositoy)),
        (typeof(IAIAssistantRepository),typeof(ApiClientAIAssistantRepository)),
        (typeof(IInteractiveScreenRepository),typeof(ApiClientInteractiveScreenRepository)),
        // User repositories
        (typeof(IUserRepository), typeof(ApiClientUserRepository)),
        //(typeof(IUserService), typeof(UserService)),
      
        (typeof(ITemplateRepository), typeof(ApiClientTemplateRepository)),
        // Person repositories
         (typeof(IPersonRepository), typeof(ApiClientPersonRepository)),
         (typeof(IPermissionRepository), typeof(ApiClientPermissionRepository)),

         (typeof(IRoleRepository), typeof(ApiClientRoleRepository)),
         (typeof(IStudentRepository), typeof(ApiClientStudentRepository)),
         (typeof(IProfessorRepository), typeof(ApiClientProfessorRepository)),
         //(typeof(IPersonService), typeof(PersonService)),
    };

    /// <summary>
    /// Configures infrastructure API client layer services in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to which the services will be added.</param>
    /// <param name="configuration">The configuration used for configuring the API client.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddInfrastructureApiClientLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Step 1: Configure authentication for the ApiClient.
        services.AddScoped<IAuthenticationProvider, AnonymousAuthenticationProvider>();
        // Step 2: Configure the request adapter.
        services.AddScoped<IRequestAdapter, HttpClientRequestAdapter>(serviceProvider =>
        {
            var adapter = new HttpClientRequestAdapter(
                serviceProvider.GetRequiredService<IAuthenticationProvider>(),
                httpClient: serviceProvider.GetRequiredService<HttpClient>());

            // Step 3: Define the base URL.
            adapter.BaseUrl = configuration["DownstreamApi:BaseUrl"];

            return adapter;
        });

        // Step 4: Register the ApiClient.
        services.AddScoped<ApiClientKiota>();
        // Step 5: Register the ApiClient repositories.
        addScopedRepositories(services);
        //services.AddAuthorizationCore();

        return services;
    }

    /// <summary>
    /// Register all repositories with a foreach loop in the _infraApiClientLayerRepositories list
    /// </summary>
    /// <param name="services">All services</param>
    private static void addScopedRepositories(IServiceCollection services)
    {
        foreach (var repository in _infraApiClientLayerRepositories)
        {
            services.AddScoped(repository.Item1, repository.Item2);
        }
    }
}