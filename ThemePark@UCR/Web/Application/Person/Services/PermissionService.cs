using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;

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
