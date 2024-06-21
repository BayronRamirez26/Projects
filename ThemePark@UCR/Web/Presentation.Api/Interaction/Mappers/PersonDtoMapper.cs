using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction.Mappers;

[Mapper]
public partial class PersonDtoMapper
{
    public static partial PersonDto FromEntityToDto(Persons personDto);

    public static string NameToString(UserNameValueObject name) => name.Value;

    //public static string MiddleNameToString(UserNameValueObject middleName) => middleName.Value;

    //public static string FirstLastNameToString(UserNameValueObject firstLasName) => firstLasName.Value;

    //public static string SecondLastNameToString(UserNameValueObject secondLastName) => secondLastName.Value;

    public static string? BirthDateToDateOnly(BirthDateValueObject birthDate) => birthDate.ToString();

    public static string PhoneNumberToString(PhoneValueObject phone) => phone.Value;

    public static string EmailToString(EmailValueObject email) => email.Value;

    public static PermissionDto? PermissionToDto(Permission? permission) => new PermissionDto(
        permission.PermissionId,
        permission.PermissionDescription.Value
    );

    public static RoleDto? RoleToDto(Role? role)
    {
        if (role == null) return null;
        var permissions = role.Permissions.Select(PermissionToDto);
        return new RoleDto(role.RoleId, role.RoleName.Value, permissions);
    } 
    public static UserDto? UserToDto(User? user)
    {
        if (user is null) return null;
        var roles = user.Roles.Select(RoleToDto);
        return new UserDto(user.UserId, user.UserNickName.Value, user.UserPasswordHash.Value, user.IsActive, user.PersonId, roles);
    } 

}