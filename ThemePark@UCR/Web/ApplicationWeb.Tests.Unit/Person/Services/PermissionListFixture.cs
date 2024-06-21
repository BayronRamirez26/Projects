using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Tests.Unit.Person.Services;

public class PermissionListFixture
{
    public IEnumerable<Permission> PermissionsList { get; }
    public IEnumerable<Permission> GetPermissionsList {  get; }

    public PermissionListFixture()
    {
        PermissionsList =
            [
            new Permission(
                Guid.NewGuid(),
                MediumName.Create("Poder iniciar clases")
                ),
            new Permission(
                Guid.NewGuid(),
                MediumName.Create("Cambiar avatares de otros usuarios")
                ),
            new Permission(
                Guid.NewGuid(),
                MediumName.Create("Modificar la pizarra")
                ),
            ];
        GetPermissionsList = PermissionsList.ToList();
    }
}
