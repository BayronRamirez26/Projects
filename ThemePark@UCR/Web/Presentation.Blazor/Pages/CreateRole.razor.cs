using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class CreateRole
    {
        private string _message = "";
        private bool HideButton = true;
        private Role role;
        public bool IsDisabled = true;
        private RoleType roletype { get; set; } = new RoleType();
        private List<Guid?> permissionIds = new();
        private IEnumerable<PermissionModel>? allPermissions;
        private bool IsAuthenticatedResult;
        string statusMessage;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            IsAuthenticatedResult = authState.User.Identity?.IsAuthenticated ?? false;
            if (IsAuthenticatedResult)
            {
                var permissions = await PermissionService.GetAllPermissionsAsync();
                allPermissions = permissions.Select(p => new PermissionModel
                {
                    Id = p.PermissionId,
                    PermissionDescription = p.PermissionDescription,
                    IsSelected = false
                }).ToList();
            }
        }

        public class RoleType
        {
            [Required(ErrorMessage = "El nombre debe ser brindado")]
            public bool IsDisabled = true;
            public string name;
            public string Name
            {
                get => name;
                set
                {
                    name = value;
                    IsDisabled = false;
                }
            }
        }

        public class PermissionModel
        {
            public Guid? Id { get; set; }
            public MediumName PermissionDescription { get; set; }
            public bool IsSelected { get; set; }
        }

        public string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                IsDisabled = false;
                StateHasChanged();
            }
        }

        private void OnSubmit(EditContext e)
        {
            submit();
        }

        private void OnReset(IBSForm bSForm)
        {
            bSForm.Reset();
        }

        private async void submit()
        {
            permissionIds = allPermissions?.Where(p => p.IsSelected).Select(p => p.Id).ToList() ?? new List<Guid?>();
            Role role = new Role(Guid.NewGuid(), MediumName.Create(Name));

            if (!string.IsNullOrEmpty(Name))
            {
                await CreateRoleCall(role, permissionIds);
                NavigationManager.NavigateTo("ShowRoles");
            }
        }

        private void GoToSR()
        {
            NavigationManager.NavigateTo("ShowRoles");
        }

        private async Task CreateRoleCall(Role role, List<Guid?> permissionIds)
        {
            try
            {
                Http.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", CurrentNavigationUser.CurrentUser.Token);
                bool result = await RoleService.CreateRole(role);
                if (result == true)
                {
                    foreach (var permission in permissionIds)
                    {
                        Console.WriteLine(permission.ToString());
                        await AssignPermissionToRoleCall(role.RoleId, (Guid)permission);
                    }
                }
                string succesMessage = "Role" + role.RoleName.Value + "created successfully";
                statusMessage = result ? succesMessage : "Failed to create role.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        private async Task AssignPermissionToRoleCall(Guid roleId, Guid permissionId)
        {
            try
            {
                Http.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", CurrentNavigationUser.CurrentUser.Token);

                bool result = await PermissionService.AssignPermissionToRole(roleId, permissionId);

                string succesMessage = "Permission assigned to Role successfully";
                statusMessage = result ? succesMessage : "Failed to create role.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }
    }
}