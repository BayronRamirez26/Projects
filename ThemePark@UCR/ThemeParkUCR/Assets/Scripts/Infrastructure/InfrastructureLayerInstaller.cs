using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using Zenject;
using CandyCoded.env;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Events;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.Utilities.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Events;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure
{

    /// <summary>
    /// Add the bindings for the infrastructure layer. 
    /// This means add services to the container that are used to interact with the API.
    /// And also register the events that are going to be used in the application that interact with the API as Infrastructure services.
    /// </summary>
    public class InfrastructureLayerInstaller : Installer<InfrastructureLayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IAuthenticationProvider>()
                .To<AnonymousAuthenticationProvider>()
                .AsTransient();

            // Get the API base URL from the environment variables.
            // This is managed by the CandyCoded.env package.
            env.TryParseEnvironmentVariable("API_BASE_URL", out string apiBaseUrl);

            Container.Bind<IRequestAdapter>()
                .To<HttpClientRequestAdapter>()
                .AsTransient()
                // Once the HttpClientRequestAdapter is instantiated, set the base URL.
                .OnInstantiated<HttpClientRequestAdapter>((injectContext, requestAdapter) =>
                {
                    requestAdapter.BaseUrl = apiBaseUrl;
                });

            Container.Bind<ApiClientKiota>()
                .ToSelf()
                .AsTransient();

            // add here the services implemeted by ous.
            Container.Bind<IBuildingRepository>()
                .To<ApiBuildingRepository>()
                .AsTransient();

            Container.Bind<ILevelRepository>()
               .To<ApiLevelRepository>()
               .AsTransient();

            Container.Bind<IDropdownCascadeRepository>()
               .To<ApiDropdownCascadeRepository>()
               .AsTransient();

            // Learning space services
            Container.Bind<IAccessPointRepository>()
               .To<ApiAccessPointRepository>()
               .AsTransient();

            // Install the SignalBusInstaller
            SignalBusInstaller.Install(Container);

            // Register the SignalBusEventChannel as the IEventChannel of Domain.Core.EventSystem
            Container.Bind<IEventChannel>()
                .To<SignalBusEventChannel>()
                .AsSingle(); // a unique channel for the whole application

            RegisterEvents();
        }


        /// <summary>
        /// Register all events that are going to be used in the application.
        /// </summary>
        private void RegisterEvents()
        {
            // Register all events here.
            // Learning Area events
            Container.DeclareSignal<FetchLevelsFromBuldingEvent>();
            Container.DeclareSignal<FetchBuildingsFromSiteEvent>();

            // Dropdown cascade events
            Container.DeclareSignal<FetchCampusesFromUniversityCascadeEvent>();
            Container.DeclareSignal<FetchSitesFromCampusCascadeEvent>();
            Container.DeclareSignal<FetchSelectedCampusEvent>();
            Container.DeclareSignal<FetchSelectedSiteEvent>();

            // Learning Space events
            Container.DeclareSignal<FetchAccessPointsFromLevelEvent>();
        }
    }
}