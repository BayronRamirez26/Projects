using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Person.Fixtures;

public class RoleValueObjectsFixture
{
    private const string kRoleNameValue = "Administrador";

    public MediumName RoleName { get; }

    public RoleValueObjectsFixture()
    {
        RoleName = MediumName.Create(kRoleNameValue);
    }

}
