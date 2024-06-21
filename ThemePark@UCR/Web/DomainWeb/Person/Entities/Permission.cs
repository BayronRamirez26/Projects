using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

public class Permission
{
    public Permission(Guid permissionId, MediumName permissionDescription)
    {
        PermissionId = permissionId;
        PermissionDescription = permissionDescription;
    }
    public Guid PermissionId { get; set; }
    public MediumName PermissionDescription { get; set; }
}