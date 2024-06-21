using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{

    public partial class ShowUserRoles
    {
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private bool IsAuthenticatedResult;
        private IEnumerable<Role>? userRoles;
        private IEnumerable<Permission>? allPermissions;
        private List<Guid?> permissionsIds = new List<Guid?>();
        private string RoleName;
        private User? user;
        private IEnumerable<Persons>? allPersons;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            IsAuthenticatedResult = authState.User.Identity?.IsAuthenticated ?? false;
            if (IsAuthenticatedResult && UserState.SelectedUser != null)
            {
                allPersons = await PersonService.GetPersonAsync();
                var selectedPerson = allPersons.
                FirstOrDefault(p => p.User != null && p.User.UserId == UserState.SelectedUser.UserId);
                userRoles = selectedPerson.User.Roles;
                user = selectedPerson.User;
            }
            allPermissions = await PermissionService.GetAllPermissionsAsync();
        }

        private bool FilterFunc1(Role element) => FilterFunc(element, searchString1);

        private bool FilterFunc(Role element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.RoleName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }


        private string statusMessage;

        private async Task CreateRole()
        {
            try
            {
                //permissionsIds = selectedPermissions.Where(p => p.Value).Select(p => p.Key).ToList();
                MediumName mediumName = new MediumName(RoleName);

                var role = new Role (Guid.NewGuid(), mediumName ); // Add other necessary properties


                bool result = await RoleService.CreateRole(role);
                statusMessage = result ? "Role created successfully." : "Failed to create role.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        private async Task AssignRoleToUser()
        {
            try
            {
                Guid userId = Guid.NewGuid(); // Example user ID
                Guid roleId = Guid.NewGuid(); // Example role ID

                bool result = await RoleService.AssignRoleToUser(userId, roleId);
                statusMessage = result ? "Role assigned to user successfully." : "Failed to assign role to user.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }


        //This should go on student or professor user flow
        private async Task RequestRoleToAdmin()
        {
            try
            {
                Guid userId = Guid.NewGuid(); // Example user ID
                Guid roleId = Guid.NewGuid(); // Example role ID

                bool result = await RoleService.RequestRoleToAdmin(userId, roleId);
                statusMessage = result ? "Role request to admin submitted successfully." : "Failed to request role to admin.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        private async Task AcceptRoleToUser()
        {
            try
            {
                Guid userId = Guid.NewGuid(); // Example user ID
                Guid roleId = Guid.NewGuid(); // Example role ID

                bool result = await RoleService.AcceptRoleToUser(userId, roleId);
                statusMessage = result ? "Role accepted for user successfully." : "Failed to accept role for user.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        private async Task DeleteRole()
        {
            try
            {
                Guid roleId = Guid.NewGuid(); // Example role ID

                bool result = await RoleService.DeleteRole(roleId);
                statusMessage = result ? "Role deleted successfully." : "Failed to delete role.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        private void NavigateToUserRoles()
        {
            NavigationManager.NavigateTo("/ManageRoles");
        }
    }
}

