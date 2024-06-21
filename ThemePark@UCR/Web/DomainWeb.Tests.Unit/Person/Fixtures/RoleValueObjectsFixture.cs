using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.Fixtures;

public class RoleValueObjectsFixture
{
    private const string kRoleNameValue = "Administrador";

    public MediumName RoleName { get; }

    public RoleValueObjectsFixture()
    {
        RoleName = MediumName.Create(kRoleNameValue);
    }

}
