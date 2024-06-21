using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.Person.Services;

public class RoleListFixture
{
    public IEnumerable<Role> RolesList { get; }
    public IEnumerable<Permission> PermissionsList { get; } // Lista utilizada para las relaciones Roles-Permiso
    public IEnumerable<Role> GetRolesList { get; }
    public RoleListFixture()
    {
        RolesList =
            [
            new Role(
                Guid.NewGuid(),
                MediumName.Create("Usuario")
                ),
            new Role(
                Guid.NewGuid(),
                MediumName.Create("Profesor")
                ),
            new Role(
                Guid.NewGuid(),
                MediumName.Create("Administrador")
                ),
            ];
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
        GetRolesList = RolesList.ToList();
    }
}
