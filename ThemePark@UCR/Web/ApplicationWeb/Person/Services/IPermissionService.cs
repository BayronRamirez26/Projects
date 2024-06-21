using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;

public interface IPermissionService
{
    public Task<IEnumerable<Permission>> GetAllPermissionsAsync();
    public Task<bool> AssignPermissionToRole(Guid roleId, Guid permissionId);
}

