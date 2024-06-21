using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Classes;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
// Here add application layer entity services
// Here add application layer entity services

namespace UCR.ECCI.PI.ThemePark_UCR.Application
{
    /// <summary>
    /// Extension method used to add services to the DI container
    /// </summary>
    public static class ApplicationLayerDependencyInjection
    {

        internal static readonly List<(Type, Type)> _appLayerServices = new()
        {
            (typeof(ISiteService), typeof(SiteService)),
            (typeof(IBuildingService), typeof(BuildingService)),
            (typeof(ILevelService), typeof(LevelService)),
            (typeof(IBOTemplateService), typeof(BOTemplateService)),
            (typeof(IBuildingObjectService), typeof(BuildingObjectService)),

            (typeof(ILearningSpaceService), typeof(LearningSpaceService)),
            (typeof(ILearningSpaceCascadeService), typeof(LearningSpaceCascadeService)),
            (typeof(IAccessPointService), typeof(AccessPointService)),
            (typeof(ILsTypeServices), typeof(LsTypeServices)),
    
            (typeof(IWhiteboardService), typeof(WhiteboardService)),
            (typeof(IAIAssistantService), typeof(AIAssistantService)),
            (typeof(IProjectorService), typeof(ProjectorService)),
            (typeof(IInteractiveScreenService), typeof(InteractiveScreenService)),

            (typeof(IPersonService), typeof(PersonService)),
            (typeof(IUserService), typeof(UserService)),
            (typeof(IRoleService), typeof(RoleService)),
            (typeof(IPermissionService), typeof(PermissionService)),
            (typeof(IProfessorService), typeof(ProfessorService)),
            (typeof(IStudentService), typeof(StudentService)),  

            (typeof(ITemplateService), typeof(TemplateService)),       
        };

        /// <summary>
        /// Adds application layer services to dependency injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
        {
            // Register all repositories with a foreach loop in the _repositories list
            foreach (var service in _appLayerServices)
            {
                services.AddScoped(service.Item1, service.Item2);
            }

            return services;
        }
    }
}
