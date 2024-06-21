using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;

public interface IPermissionService
{
    public Task<IEnumerable<Permission>> GetAllPermissionsAsync();

    public Task<bool> AssignPermissionToRole(Guid roleId, Guid permissionId);
}

