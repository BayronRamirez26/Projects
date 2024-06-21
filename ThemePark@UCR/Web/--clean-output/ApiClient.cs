// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateAIAssistant;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateAccessPoint;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateBuilding;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateInteractiveScreens;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateLearningspaceType;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateLearningspaces;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateLevel;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateProjector;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.CreateWhiteboard;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.DeleteBuilding;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.DeleteLearningSpace;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.DeleteLevel;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.GetBuildingofsite;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.GetCampusofuniversity;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.GetLearningSpaceById;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.GetLevelofbuilding;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.GetSiteofcampus;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LevelByBuilding;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ListAIAssistant;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ListAccessPoints;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ListBuildings;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ListInteractiveScreens;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ListLearningspaces;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ListLearningspacetypes;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ListProjectors;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ListWhiteboard;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ModifyAccessPoint;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ModifyLearningSpace;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ModifyLearningspaceType;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ShowActiveUsers;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.SiteProperties;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.UpdateBuilding;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.UpdateLevel;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient {
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    public class ApiClient : BaseRequestBuilder 
    {
        /// <summary>The createAccessPoint property</summary>
        public CreateAccessPointRequestBuilder CreateAccessPoint
        {
            get => new CreateAccessPointRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The createAIAssistant property</summary>
        public CreateAIAssistantRequestBuilder CreateAIAssistant
        {
            get => new CreateAIAssistantRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The createBuilding property</summary>
        public CreateBuildingRequestBuilder CreateBuilding
        {
            get => new CreateBuildingRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The createInteractiveScreens property</summary>
        public CreateInteractiveScreensRequestBuilder CreateInteractiveScreens
        {
            get => new CreateInteractiveScreensRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The createLearningspaces property</summary>
        public CreateLearningspacesRequestBuilder CreateLearningspaces
        {
            get => new CreateLearningspacesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The createLearningspaceType property</summary>
        public CreateLearningspaceTypeRequestBuilder CreateLearningspaceType
        {
            get => new CreateLearningspaceTypeRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The createLevel property</summary>
        public CreateLevelRequestBuilder CreateLevel
        {
            get => new CreateLevelRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The createProjector property</summary>
        public CreateProjectorRequestBuilder CreateProjector
        {
            get => new CreateProjectorRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The createWhiteboard property</summary>
        public CreateWhiteboardRequestBuilder CreateWhiteboard
        {
            get => new CreateWhiteboardRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deleteBuilding property</summary>
        public DeleteBuildingRequestBuilder DeleteBuilding
        {
            get => new DeleteBuildingRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deleteLearningSpace property</summary>
        public DeleteLearningSpaceRequestBuilder DeleteLearningSpace
        {
            get => new DeleteLearningSpaceRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deleteLevel property</summary>
        public DeleteLevelRequestBuilder DeleteLevel
        {
            get => new DeleteLevelRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The getBuildingofsite property</summary>
        public GetBuildingofsiteRequestBuilder GetBuildingofsite
        {
            get => new GetBuildingofsiteRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The getCampusofuniversity property</summary>
        public GetCampusofuniversityRequestBuilder GetCampusofuniversity
        {
            get => new GetCampusofuniversityRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The getLearningSpaceById property</summary>
        public GetLearningSpaceByIdRequestBuilder GetLearningSpaceById
        {
            get => new GetLearningSpaceByIdRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The getLevelofbuilding property</summary>
        public GetLevelofbuildingRequestBuilder GetLevelofbuilding
        {
            get => new GetLevelofbuildingRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The getSiteofcampus property</summary>
        public GetSiteofcampusRequestBuilder GetSiteofcampus
        {
            get => new GetSiteofcampusRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The levelByBuilding property</summary>
        public LevelByBuildingRequestBuilder LevelByBuilding
        {
            get => new LevelByBuildingRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The listAccessPoints property</summary>
        public ListAccessPointsRequestBuilder ListAccessPoints
        {
            get => new ListAccessPointsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The listAIAssistant property</summary>
        public ListAIAssistantRequestBuilder ListAIAssistant
        {
            get => new ListAIAssistantRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The listBuildings property</summary>
        public ListBuildingsRequestBuilder ListBuildings
        {
            get => new ListBuildingsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The listInteractiveScreens property</summary>
        public ListInteractiveScreensRequestBuilder ListInteractiveScreens
        {
            get => new ListInteractiveScreensRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The listLearningspaces property</summary>
        public ListLearningspacesRequestBuilder ListLearningspaces
        {
            get => new ListLearningspacesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The listLearningspacetypes property</summary>
        public ListLearningspacetypesRequestBuilder ListLearningspacetypes
        {
            get => new ListLearningspacetypesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The listProjectors property</summary>
        public ListProjectorsRequestBuilder ListProjectors
        {
            get => new ListProjectorsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The listWhiteboard property</summary>
        public ListWhiteboardRequestBuilder ListWhiteboard
        {
            get => new ListWhiteboardRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The modifyAccessPoint property</summary>
        public ModifyAccessPointRequestBuilder ModifyAccessPoint
        {
            get => new ModifyAccessPointRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The modifyLearningSpace property</summary>
        public ModifyLearningSpaceRequestBuilder ModifyLearningSpace
        {
            get => new ModifyLearningSpaceRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The modifyLearningspaceType property</summary>
        public ModifyLearningspaceTypeRequestBuilder ModifyLearningspaceType
        {
            get => new ModifyLearningspaceTypeRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The showActiveUsers property</summary>
        public ShowActiveUsersRequestBuilder ShowActiveUsers
        {
            get => new ShowActiveUsersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The siteProperties property</summary>
        public SitePropertiesRequestBuilder SiteProperties
        {
            get => new SitePropertiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The updateBuilding property</summary>
        public UpdateBuildingRequestBuilder UpdateBuilding
        {
            get => new UpdateBuildingRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The updateLevel property</summary>
        public UpdateLevelRequestBuilder UpdateLevel
        {
            get => new UpdateLevelRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="ApiClient"/> and sets the default values.
        /// </summary>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApiClient(IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>())
        {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
        }
    }
}
