using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.AssignPermissionToRole.AssignPermissionToRoleRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Repositories;

public class ApiClientPermissionRepository : IPermissionRepository
{
    private readonly ApiClientKiota _apiClient;

    public ApiClientPermissionRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<bool> AssignPermissionToRole(Guid roleId, Guid permissionId)
    {
        var assignPermissionToRole =  new Client.Models.AssignPermissionToRoleRequest
        {
            RoleId = roleId,
            PermissionId = permissionId
        };
        var requestConfiguration = new Action<RequestConfiguration<DefaultQueryParameters>>(config =>
        {
        });

        var AssignPermissionToRoleResponse = await _apiClient.AssignPermissionToRole.PostAsync(assignPermissionToRole, requestConfiguration);

        return AssignPermissionToRoleResponse ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
    {
        var response = await _apiClient.GetPermissions.GetAsync(); //Para poder hacer await de un task, el método debe estar como async
        var permissionEntities = response?.Permissions?.Select(PermissionDtoMapper.ToEntity)
            ?? throw new NullReferenceException();
        return permissionEntities;

    }
}
