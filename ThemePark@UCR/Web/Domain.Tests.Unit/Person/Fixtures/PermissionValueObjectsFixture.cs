using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Person.Fixtures;

public class PermissionValueObjectsFixture
{
    private const string kPermissionDescriptionValue = "Este permiso te permite modificar el contenido dentro de la pizarra de un aula.";

    public MediumName PermissionDescription { get; private set; }

    public PermissionValueObjectsFixture()
    {
        PermissionDescription = MediumName.Create(kPermissionDescriptionValue);
    }
}
