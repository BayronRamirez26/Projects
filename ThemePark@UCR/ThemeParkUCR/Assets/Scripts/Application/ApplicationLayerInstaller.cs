using UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Application.Utilities.Services;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Application
{
    public class ApplicationLayerInstaller : Installer<ApplicationLayerInstaller>
    {
       public override void InstallBindings()
        {
            // bidings of learning area services
            Container.Bind<IBuildingService>()
                .To<BuildingService>()
                .AsTransient();

            Container.Bind<ILevelService>()
                .To<LevelService>()
                .AsTransient();

            Container.Bind<IDropdownCascadeService>()
                .To<DropdownCascadeService>()
                .AsTransient();

            Container.Bind<IAccessPointService>()
                .To<AccessPointService>()
                .AsTransient();
        }
    }
}
