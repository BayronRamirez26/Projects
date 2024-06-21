using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.Fixtures;

public class PermissionValueObjectsFixture
{
    private const string kPermissionDescriptionValue = "Este permiso te permite modificar el contenido dentro de la pizarra de un aula.";

    public MediumName PermissionDescription { get; private set; }

    public PermissionValueObjectsFixture()
    {
        PermissionDescription = MediumName.Create(kPermissionDescriptionValue);
    }
}
