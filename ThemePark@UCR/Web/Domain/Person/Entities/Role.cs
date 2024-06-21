using Microsoft.EntityFrameworkCore.Metadata;
using System.Security;
using System.Text.Json.Serialization;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

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

    [JsonIgnore]
    public ICollection<User> Users { get; set; } // Reference navigation property to dependent many to many
}