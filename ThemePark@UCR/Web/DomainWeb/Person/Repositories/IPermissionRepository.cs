using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;

public interface IPermissionRepository
{
    public Task<IEnumerable<Permission>> GetAllPermissionsAsync();
    public Task<bool> AssignPermissionToRole(Guid roleId, Guid permissionId);

}

