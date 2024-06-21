using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;

public interface IRoleRepository
{
    public Task<IEnumerable<Role>> GetAllRolesAsync();
    public Task<bool> CreateRole(Role roleObject);
    public Task<bool> AssignRoleToUser(Guid userId, Guid roleId);

    public Task<bool> RequestRoleToAdmin(Guid userId, Guid roleId);

    public Task<bool> AcceptRoleToUser(Guid userId, Guid roleId);

    public Task<bool> DeleteRole(Guid roleId);

    public Task<bool> UnassignRoleToUser(Guid userId, Guid roleId);
}
