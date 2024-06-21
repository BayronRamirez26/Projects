using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ManageUserRoles
    {
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private bool IsAuthenticatedResult;
        private IEnumerable<Role>? userRoles;
        private IEnumerable<Role>? allRoles;
        private IEnumerable<Permission>? allPermissions;
        private List<Guid?> permissionsIds = new List<Guid?>();
        private string? RoleName;
        private User? user;
        private Dictionary<Guid, string> roleStatus = new();
        private string? statusMessage;
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
                allRoles = await RoleService.GetAllRolesAsync();
                // Initialize roleStatus dictionary with default values
                foreach (var role in allRoles)
                {
                    if (IsRoleAssignedToUser(role.RoleId))
                    {
                        roleStatus[role.RoleId] = "Asignado";
                    }
                    else
                    {
                        roleStatus[role.RoleId] = "No Asignado";
                    }
                }
            }
            allPermissions = await PermissionService.GetAllPermissionsAsync();

            Debug.WriteLine("I enter OnInitializedAsync");
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

        private bool IsRoleAssignedToUser(Guid roleId)
        {
            return userRoles?.Any(r => r.RoleId == roleId) ?? false;
        }

        private bool isRoleAssignedInternal(Guid roleId)
        {
            return roleStatus[roleId] == "Asignado";
        }

        private async void OnRoleStatusChanged(string newValue, Guid roleId)
        {
            ValidationService service = new ValidationService();
            if (newValue == "Asignado")
            {
                if (!isRoleAssignedInternal(roleId))
                {
                    roleStatus[roleId] = newValue;
                    Http.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue
                    ("Bearer", CurrentNavigationUser.CurrentUser.Token);
                    await AssignRoleToUser(user.UserId, roleId);
                }
            }
            else if (newValue == "No Asignado")
            {
                if (isRoleAssignedInternal(roleId))
                {
                    roleStatus[roleId] = newValue;
                    Http.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue
                    ("Bearer", CurrentNavigationUser.CurrentUser.Token);
                    await UnassignRoleToUser(user.UserId, roleId);
                }
            }

            // Revisar que el state, en efecto, cambie.
            StateHasChanged();
        }

        private async Task AssignRoleToUser(Guid userId, Guid roleId)
        {
            try
            {
                bool result = await RoleService.AssignRoleToUser(userId, roleId);
                statusMessage = result ? "Role assigned to user successfully." : "Failed to assign role to user.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        private async Task UnassignRoleToUser(Guid userId, Guid roleId)
        {
            try
            {
                bool result = await RoleService.UnassignRoleToUser(userId, roleId);
                statusMessage = result ? "Role unassigned to user successfully." : "Failed to unassign role to user.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }
    }
}