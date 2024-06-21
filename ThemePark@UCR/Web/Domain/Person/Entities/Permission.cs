using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using System.Text.Json.Serialization;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

public class Permission
{
    public Permission(Guid permissionId, MediumName permissionDescription)
    {
        PermissionId = permissionId;
        PermissionDescription = permissionDescription;
    }
    public Guid PermissionId { get; set; }
    public MediumName PermissionDescription { get; set; }

    [JsonIgnore]
    public ICollection<Role> Roles { get; set; } // Reference navigation property to dependent many to many
}