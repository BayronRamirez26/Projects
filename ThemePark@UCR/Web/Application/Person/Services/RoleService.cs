using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        return _roleRepository.GetAllRolesAsync();
    }
    public Task<bool> CreateRole(Role roleObject)
    {
        return _roleRepository.CreateRole(roleObject);
    }
    public Task<bool> AssignRoleToUser(Guid userId, Guid roleId)
    {
        return _roleRepository.AssignRoleToUser(userId, roleId);
    }
    public Task<bool> RequestRoleToAdmin(Guid userId, Guid roleId)
    {
        return _roleRepository.RequestRoleToAdmin(userId, roleId);
    }

    public Task<bool> AcceptRoleToUser(Guid userId, Guid roleId)
    {
        return _roleRepository.AcceptRoleToUser(userId, roleId);
    }

    public Task<bool> DeleteRole(Guid roleId)
    {
        return _roleRepository.DeleteRole(roleId);
    }

    public Task<bool> UnassignRoleToUser(Guid userId, Guid roleId)
    {
        return _roleRepository.UnassignRoleToUser(userId, roleId);
    }
}

