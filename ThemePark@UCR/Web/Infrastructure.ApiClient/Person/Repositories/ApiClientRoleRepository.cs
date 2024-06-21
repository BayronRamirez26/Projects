using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.AcceptRoleToUser.AcceptRoleToUserRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.AssignRoleToUser.AssignRoleToUserRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.DeleteRole.DeleteRoleRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.RequestRoleToAdmin.RequestRoleToAdminRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.UnassignRoleToUser.UnassignRoleToUserRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Repositories;

internal class ApiClientRoleRepository : IRoleRepository
{
    private readonly ApiClientKiota _apiClient;

    public ApiClientRoleRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        var response = await _apiClient.GetRoles.GetAsync(); //Para poder hacer await de un task, el método debe estar como async
        var roleEntities = response?.Roles?.Select(RoleDtoMapper.ToEntity)
            ?? throw new NullReferenceException();
        return roleEntities;
    }

    public async Task<bool> CreateRole(Role roleObject)
    {
        try
        {
            //List<Guid> nonNullablePermissionIds = permissionIds
            //                                .Where(id => id.HasValue)
            //                                .Select(id => id.Value)
            //                                .ToList();

            //Models.Role roleModels = new Models.Role();
            //roleModels.RoleId = roleObject.RoleId;
            //roleModels.RoleName = new Models.MediumName();

            //roleModels.RoleName.Value = roleObject.RoleName.Value;
            //var permissions = GetPermissions();
            //var permissionModels = permissions.Select(p => KiotaPermissionDtoMapper.ToEntity(p)).ToList();

            var roleModels = KiotaRoleDtoMapper.ToCreateRoleRequest(roleObject);
            //roleModel.Permissions = permissionModels;
            //Models.CreateRoleRequestDto requestDto = new Models.CreateRoleRequestDto();
            //requestDto.RoleObject = roleModels;
            //requestDto.PermissionIds = permissionIds;


            // return (bool)await _apiClient.CreateRole.PostAsync(requestDto);
            try
            {
                var output = await _apiClient.CreateRole.PostAsync(roleModels);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder: {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models: {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> AssignRoleToUser(Guid userId, Guid roleId)
    {
        var assignRoleToUserRequest = new Client.Models.AssignRoleToUserRequest
        {
            UserId = userId,
            RoleId = roleId
        };

        var requestConfiguration = new Action<RequestConfiguration<DefaultQueryParameters>>(config =>
        {           
        });

        var AssignRoleToUserResponse = await _apiClient.AssignRoleToUser.PostAsync(assignRoleToUserRequest, requestConfiguration);

        return AssignRoleToUserResponse ?? throw new NullReferenceException();
    }

    public async Task<bool> RequestRoleToAdmin(Guid userId, Guid roleId)
    {
        var requestRoleToAdmin = new Client.Models.RequestRoleToAdminRequest
        {
            UserId = userId,
            RoleId = roleId
        };

        var requestConfiguration = new Action<RequestConfiguration<DefaultQueryParameters>>(config =>
        {

        });

        var RequestRoleToAdminResponse = await _apiClient.RequestRoleToAdmin.PostAsync(requestRoleToAdmin, requestConfiguration);

        return RequestRoleToAdminResponse ?? throw new NullReferenceException();
    }

    public async Task<bool> AcceptRoleToUser(Guid userId, Guid roleId)
    {
        var acceptRoleToUser = new Client.Models.AcceptRoleToUserRequest
        {
            UserId = userId,
            RoleId = roleId
        };

        var requestConfiguration = new Action<RequestConfiguration<DefaultQueryParameters>>(config =>
        {
        });

        var AcceptRoleToUserResponse = await _apiClient.AcceptRoleToUser.PostAsync(acceptRoleToUser, requestConfiguration);
        return AcceptRoleToUserResponse ?? throw new NullReferenceException();
    }
    public async Task<bool> DeleteRole(Guid roleId)
    {
        var requestConfiguration = new Action<RequestConfiguration<DeleteRoleRequestBuilderDeleteQueryParameters>>(config =>
        {
            config.QueryParameters = new DeleteRoleRequestBuilderDeleteQueryParameters
            {
                RoleId = roleId
            };
        });

        var deleteRoleResponse = await _apiClient.DeleteRole.DeleteAsync(requestConfiguration);

        return deleteRoleResponse ?? throw new NullReferenceException();
    }

    public async Task<bool> UnassignRoleToUser(Guid userId, Guid roleId)
    {
        var unassignRoleToUserRequest = new Client.Models.UnassignRoleToUserRequest
        {
            UserId = userId,
            RoleId = roleId
        };

        var requestConfiguration = new Action<RequestConfiguration<DefaultQueryParameters>>(config =>
        {
        });

        var deleteRoleResponse = await _apiClient.UnassignRoleToUser.PostAsync(unassignRoleToUserRequest,requestConfiguration);

        return deleteRoleResponse ?? throw new NullReferenceException();
    }
}
