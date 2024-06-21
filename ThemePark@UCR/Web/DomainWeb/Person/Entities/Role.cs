using System.Security;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

public class Role
{
    public Role(Guid roleId, MediumName roleName)
    {
        RoleId = roleId;
        RoleName = roleName;
        Permissions = new List<Permission>();
    }

    public Guid RoleId { get; set; }
    public MediumName RoleName { get; set; }
    public ICollection<Permission> Permissions { get; set; }
}