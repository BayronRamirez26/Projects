using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ShowRoles
    {
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private bool IsAuthenticatedResult;
        private IEnumerable<Role>? allRoles;
        private IEnumerable<Permission>? allPermissions;
        private string? RoleName;
       
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            IsAuthenticatedResult = authState.User.Identity?.IsAuthenticated ?? false;
            if (IsAuthenticatedResult)
            {
                allRoles = await RoleService.GetAllRolesAsync();
            }
        }


        private bool DeleteRole(Role element)
        {
            RoleService.DeleteRole(element.RoleId);
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
            return true;
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
    }
}