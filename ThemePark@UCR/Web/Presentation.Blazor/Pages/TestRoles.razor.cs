
using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages;
public partial class TestRoles
{
    //List used to save all the permission that will go inside a role
    //Right now is adding al the permissions

    //Ask the user of the permissions
    private List<Guid?> permissionsIds = new List<Guid?>
    {
        Guid.Parse("60b621bf-a23d-4e89-98ab-25771f88909f"),
        Guid.Parse("434f7bfc-947a-414c-85cf-6d4fe9e98a7f"),
        Guid.Parse("5ef25d03-e2c3-454b-b71f-bcfe0a271f5a"),
        Guid.Parse("e5187d01-874e-4c9b-bd55-74a204fbbea2"),
        Guid.Parse("76cbf19a-efec-42eb-81fc-b267af35db56")
    };
    //List of all permission available
    private IEnumerable<Permission>? allPermissions;

    //save the guid used to create a new role and assign it to a user
    Guid saveRoleId;
    string statusMessage;

    //List of all roles availabe
    private IEnumerable<Role>? allRoles;

    protected override async Task OnInitializedAsync()
    {
        allPermissions = await PermissionService.GetAllPermissionsAsync();
        allRoles = await RoleService.GetAllRolesAsync();
    }


    //As an admin:
    private async Task CreateRole()
    {
        try
        {
            string randomName = GenerateRandomName(); // Generate a random name
            MediumName mediumName = new MediumName(randomName);
            saveRoleId = Guid.NewGuid();
            var role = new Role(saveRoleId, mediumName); // Add other necessary properties



            bool result = await RoleService.CreateRole(role);

            string succesMessage = "Role" + role.RoleName.Value + "created successfully"; 
            statusMessage = result ? succesMessage : "Failed to create role.";
        }
        catch (Exception ex)
        {
            statusMessage = $"Error: {ex.Message}";
        }
    }


    //As and admin:
    private async Task AssignRoleToUser()
    {
        try
        {
            Guid userId = Guid.Parse("3a3f15d4-6107-46f5-878a-c0615287e2f4"); // 
            Guid roleId = saveRoleId; // Example role ID 

            //Active = true 
            bool result = await RoleService.AssignRoleToUser(userId, roleId);//UserHaveRoles
            statusMessage = result ? "Role assigned to user successfully." : "Failed to assign role to user.";
        }
        catch (Exception ex)
        {
            statusMessage = $"Error: {ex.Message}";
        }
    }

    //As a student:
    private async Task RequestRoleToAdmin()
    {
        try
        {
            Guid userId = Guid.Parse("3a3f15d4-6107-46f5-878a-c0615287e2f4"); // Example user ID // Example user ID
            Guid roleId = saveRoleId; // Example role ID


            //Active = false 
            bool result = await RoleService.RequestRoleToAdmin(userId, roleId);//UserHaveRoles
            statusMessage = result ? "Role request to admin submitted successfully." : "Failed to request role to admin.";
        }
        catch (Exception ex)
        {
            statusMessage = $"Error: {ex.Message}";
        }
    }

    //As an admin:

    private async Task AcceptRoleToUser()
    {
        try
        {
            Guid userId = Guid.Parse("3a3f15d4-6107-46f5-878a-c0615287e2f4"); // Example user ID // Example user ID
            Guid roleId = saveRoleId; // Example role ID

            //Active = true
            bool result = await RoleService.AcceptRoleToUser(userId, roleId);
            statusMessage = result ? "Role accepted for user successfully." : "Failed to accept role for user.";
        }
        catch (Exception ex)
        {
            statusMessage = $"Error: {ex.Message}";
        }
    }

    //As an admin:
    private async Task DeleteRole()
    {
        try
        {
            Guid roleId = saveRoleId; // Example role ID

            bool result = await RoleService.DeleteRole(roleId);
            statusMessage = result ? "Role deleted successfully." : "Failed to delete role.";
        }
        catch (Exception ex)
        {
            statusMessage = $"Error: {ex.Message}";
        }
    }


     private string GenerateRandomName()
    {
        // Generate a random string of characters
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var randomName = new string(Enumerable.Repeat(chars, 10) // Generate a 10-character random string
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return randomName;
    }

}
