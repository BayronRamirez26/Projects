using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;
    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }
    public Task<IEnumerable<Permission>> GetAllPermissionsAsync()
    {
        return _permissionRepository.GetAllPermissionsAsync();
    }

    public Task<bool> AssignPermissionToRole(Guid roleId, Guid permissionId)
    {
        return _permissionRepository.AssignPermissionToRole(roleId, permissionId);
    }
}
