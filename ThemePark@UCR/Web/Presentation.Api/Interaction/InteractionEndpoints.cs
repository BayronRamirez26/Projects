using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Responses;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Mappers;
using Microsoft.AspNetCore.Builder;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.User;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.Person;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.Role;
using Azure.Core;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Requests.Permission;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction;

public static class InteractionEndpoints
{

    // USER ENDPOINTS
    public static async Task<GetUserResponse> GetUserCredentialsAsync([FromServices] IUserService userService)
    {
        var userEntities = await userService.GetUserCredentialsAsync();
        var userDtos = userEntities.Select(UserDtoMapper.FromEntityToDto);

        return new GetUserResponse(userDtos);
    }

    public static async Task<bool> CreateUserAsync([FromServices] IUserService userService,
        [FromBody] CreateUserRequest request)
    {
        var user = new User(
            Guid.NewGuid(),
            new UserNameValueObject(request.UserNickName),
            new PasswordValueObject(request.UserPasswordHash),
            true,
            request.PersonId
        );
        return await userService.CreateUserAsync(user);
    }

    // PERSON ENDPOINTS
    public static async Task<GetPersonResponse> GetPersonAsync([FromServices] IPersonService personService) 
    {
        var personEntities = await personService.GetPersonAsync();
        var personDtos = personEntities.Select(PersonDtoMapper.FromEntityToDto);

        return new GetPersonResponse(personDtos);
    }

    public static async Task<bool> CreatePersonAsync([FromServices] IPersonService personService,
        [FromBody] CreatePersonRequest request)
    {
        var person = new Persons(
            Guid.NewGuid(),
            new UserNameValueObject(request.FirstName),
            request.MiddleName != null ? new UserNameValueObject(request.MiddleName) : null,
            new UserNameValueObject(request.FirstLastName),
            request.SecondLastName != null ? new UserNameValueObject(request.SecondLastName) : null,
            request.BirthDate.HasValue ? new BirthDateValueObject(request.BirthDate) : BirthDateValueObject.Invalid,
            request.PhoneNumber != null ? new PhoneValueObject(request.PhoneNumber) : null,
            request.Email != null ? new EmailValueObject(request.Email) : null
        );
        return await personService.CreatePersonAsync(person);
    }

    public static async Task<bool> DeletePersonAsync([FromServices] IPersonService personService,
         Guid personId)
    {
        return await personService.DeletePersonAsync(personId);
    }

    public static async Task<bool> UpdatePersonAsync([FromServices] IPersonService personService,
     [FromBody] UpdatePersonRequest request)
    {
        var person = new Persons(
            request.PersonId,
            new UserNameValueObject(request.FirstName),
            request.MiddleName != null ? new UserNameValueObject(request.MiddleName) : null,
            new UserNameValueObject(request.FirstLastName),
            request.SecondLastName != null ? new UserNameValueObject(request.SecondLastName) : null,
            request.BirthDate.HasValue ? new BirthDateValueObject(request.BirthDate) : BirthDateValueObject.Invalid,
            request.PhoneNumber != null ? new PhoneValueObject(request.PhoneNumber) : null,
            request.Email != null ? new EmailValueObject(request.Email) : null
        );
        return await personService.UpdatePersonAsync(person);
    }

    // ROLE ENDPOINTS
    public static async Task<GetRolesResponse> GetAllRolesAsync([FromServices] IRoleService roleService)
    {
        var roleEntities = await roleService.GetAllRolesAsync();
        var roleDtos = roleEntities.Select(RoleDtoMapper.FromEntityToDto);

        return new GetRolesResponse(roleDtos);
    }

    public static async Task<bool> CreateRole([FromServices] IRoleService roleService,
        [FromBody] CreateRoleRequest request)
    {
        var roleId = request.RoleId; // Generate a new RoleId
        var roleName = new MediumName(request.RoleName);          

        var role = new Role(roleId, roleName);
        return await roleService.CreateRole(role);
    }

    public static async Task<bool> AssignRoleToUser([FromServices] IRoleService roleService,
        [FromBody] AssignRoleToUserRequest request)
    {
        return await roleService.AssignRoleToUser(request.UserId, request.RoleId);
    }

    public static async Task<bool> UnassignRoleToUser([FromServices] IRoleService roleService,
        [FromBody] UnassignRoleToUserRequest request)
    {
        return await roleService.UnassignRoleToUser(request.UserId, request.RoleId);
    }

    public static async Task<bool> RequestRoleToAdmin([FromServices] IRoleService roleService,
         [FromBody] RequestRoleToAdminRequest request)
    {
        return await roleService.RequestRoleToAdmin(request.UserId, request.RoleId);
    }

    public static async Task<bool> AcceptRoleToUser([FromServices] IRoleService roleService,
         [FromBody] AcceptRoleToUserRequest request)
    {
        return await roleService.AcceptRoleToUser(request.UserId, request.RoleId);
    }

    public static async Task<bool> DeleteRole([FromServices] IRoleService roleService,
         Guid roleId)
    {
        return await roleService.DeleteRole(roleId);
    }


    // PERMISSION ENDPOINTS
    public static async Task<GetPermissionsResponse> GetAllPermissionsAsync([FromServices] IPermissionService permissionService)
    {
        var permissionEntities = await permissionService.GetAllPermissionsAsync();
        var permissionDtos = permissionEntities.Select(PermissionDtoMapper.FromEntityToDto);

        return new GetPermissionsResponse(permissionDtos);
    }

    public static async Task<bool> AssignPermissionToRole([FromServices] IPermissionService permissionService,
        [FromBody] AssignPermissionToRoleRequest request)
    {
        return await permissionService.AssignPermissionToRole(request.RoleId, request.PermissionId);
    }


    // STUDENT ENDPOINTS

    public static async Task<GetStudentResponse> GetStudentsAsync([FromServices] IStudentService studentService)
    {
        var studentEntities = await studentService.GetStudentsAsync();
        var studentDtos = studentEntities.Select(StudentDtoMapper.FromEntityToDto);

        return new GetStudentResponse(studentDtos);
    }

    public static async Task<Student> GetStudentByIdAsync([FromServices] IStudentService studentService, Guid studentId)
    {
        return await studentService.GetStudentByIdAsync(studentId);
    }

    public static async Task<bool> DeactivateStudentAsync([FromServices] IStudentService studentService,
           [FromRoute] Guid studentId)
    {
            return await studentService.DeactivateStudentAsync(studentId);
    }

    public static async Task<bool> AssignPersonToStudentAsync([FromServices] IStudentService studentService,
            [FromQuery] Guid personId,
            [FromQuery] string studentCard)
    {
        return await studentService.AssignPersonToStudentAsync(personId, studentCard);
    }


    // PROFESSOR ENDPOINTS

    public static async Task<GetProfessorResponse> GetProfessorAsync([FromServices] IProfessorService professorService)
    {
        var professorEntities = await professorService.GetProfessorsAsync();
        var professorDtos = professorEntities.Select(ProfessorDtoMapper.FromEntityToDto);

        return new GetProfessorResponse(professorDtos);
    }

    public static async Task<Professor> GetProfessorByIdAsync([FromServices] IProfessorService professorService, Guid professorId)
    {
        return await professorService.GetProfessorByIdAsync(professorId);
    }
    public static async Task<bool> DeactivateProfessorAsync(
            [FromServices] IProfessorService professorService,
            [FromRoute] Guid professorId)
    {
         return await professorService.DeactivateProfessorAsync(professorId);
    }
    public static async Task<bool> AssignPersonToProfessorAsync(
            [FromServices] IProfessorService professorService,
            [FromQuery] Guid personId,
            [FromQuery] string institutionalEmail)
    {
        var emailValueObject = InstitutionalEmailValueObject.Create(institutionalEmail);
        return await professorService.AssignPersonToProfessorAsync(personId, emailValueObject);
    }


    public static IEndpointRouteBuilder RegisterInteractionEndpoints(this IEndpointRouteBuilder builder)
    {
        // USER REGISTER
        builder.MapGet("/show-active-users", GetUserCredentialsAsync)
            .WithName("ShowActiveUsers")
            .WithOpenApi();

        builder.MapPost("/create-user", CreateUserAsync)
        .WithName("CreateUsers")
        .WithOpenApi();

        // PERSON REGISTER

        builder.MapGet("/get-persons", GetPersonAsync)
        .WithName("Get persons")
        .WithOpenApi();

        builder.MapPost("/create-person", CreatePersonAsync)
        .WithName("Add person")
        .WithOpenApi();

        builder.MapDelete("/delete-person", DeletePersonAsync)
        .WithName("delete person")
        .WithOpenApi();

        builder.MapPut("/update-person",UpdatePersonAsync)
        .WithName("update person")
        .WithOpenApi();

        // ROLE REGISTER
        builder.MapGet("/get-roles", GetAllRolesAsync)
            .WithName("Get Roles")
            .WithOpenApi();

        builder.MapPost("/create-role", CreateRole)
        .WithName("CreateRole")
        .RequireAuthorization("Create")
        .WithOpenApi();

        builder.MapPost("/assign-role-to-user", AssignRoleToUser)
        .WithName("Assignrotetouser")
        .RequireAuthorization("Update")
        .WithOpenApi();

        builder.MapPost("/unassign-role-to-user", UnassignRoleToUser)
        .WithName("Unassignroletouser")
        .RequireAuthorization("Update")
        .WithOpenApi();

        builder.MapPost("/request-role-to-admin", RequestRoleToAdmin)
        .WithName("Requestroletoadmin")
        .WithOpenApi();

        builder.MapPost("/accept-role-to-user", AcceptRoleToUser)
        .WithName("Acceptroletouser")
        .WithOpenApi();

        builder.MapDelete("/delete-role", DeleteRole)
        .WithName("Deleterole")
        .WithOpenApi();

        // PERMISSION REGISTER
        builder.MapGet("/get-permissions", GetAllPermissionsAsync)
            .WithName("Get Permissions")
            .WithOpenApi();

        builder.MapPost("/assign-permission-to-role", AssignPermissionToRole)
        .WithName("Assignpermtetorole")
        .WithOpenApi();

        // STUDENT REGISTER
        builder.MapGet("/get-students", GetStudentsAsync)
        .WithName("GetStudents")
        .WithOpenApi();

        builder.MapGet("/get-student/{id}", GetStudentByIdAsync)
        .WithName("GetStudentById")
        .WithOpenApi();

        builder.MapPost("/assign-person-to-student", AssignPersonToStudentAsync)
        .WithName("AssignPersonToStudent")
        .WithOpenApi();

        builder.MapPost("/deactivate-student/{studentId}", DeactivateStudentAsync)
        .WithName("DeactivateStudent")
        .WithOpenApi();

        // PROFESSOR REGISTER
        builder.MapGet("/get-professors", GetProfessorAsync)
        .WithName("GetProfessors")
        .WithOpenApi();

        builder.MapGet("/get-professor/{id}", GetProfessorByIdAsync)
        .WithName("GetProfessorById")
        .WithOpenApi();

        builder.MapPost("/assign-person-to-professor", AssignPersonToProfessorAsync)
        .WithName("AssignPersonToProfessor")
        .WithOpenApi();


        builder.MapPost("/deactivate-professor/{professorId}", DeactivateProfessorAsync)
        .WithName("DeactivateProfessor")
        .WithOpenApi();

        return builder;
    }
}
