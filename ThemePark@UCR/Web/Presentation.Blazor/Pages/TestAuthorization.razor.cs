using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
public partial class TestAuthorization
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


    //As an admin:
    private async Task CreateRole()
    {
        try
        {
            string randomName = GenerateRandomName(); // Generate a random name
            MediumName mediumName = new MediumName(randomName);
            saveRoleId = Guid.NewGuid();
            var role = new Role(saveRoleId, mediumName); // Add other necessary properties



            bool result = await RoleService.CreateRole(role, permissionsIds);

            string succesMessage = "Role" + role.RoleName.Value + "created successfully";
            statusMessage = result ? succesMessage : "Failed to create role.";
        }
        catch (Exception ex)
        {
            statusMessage = $"Error: {ex.Message}";
        }
    }
}