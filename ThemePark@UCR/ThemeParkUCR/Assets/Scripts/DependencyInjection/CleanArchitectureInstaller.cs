using UCR.ECCI.PI.ThemePark_UCR.Unity.Application;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure;
using Zenject;

/// <summary>
///  Add the bindings for the Clean Architecture. 
///  Add infrastructure and application layer installers. With their services and repositories.
/// </summary>
public class CleanArchitectureInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        InfrastructureLayerInstaller.Install(Container);
        ApplicationLayerInstaller.Install(Container);
    }
}