using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper] // Esto es para que Mapper haga la generalización automática

internal static partial class UserDtoMapper
{
    //Descomment after kiota

    internal static partial DomainWeb.Person.Entities.User ToEntity(UserDto userDto);

    internal static DomainWeb.Person.ValueObjects.UserNameValueObject ToUserNameDto(string? usernameDto)
    {
        return DomainWeb.Person.ValueObjects.UserNameValueObject.Create(usernameDto);
    }

    internal static DomainWeb.Person.ValueObjects.PasswordValueObject ToPasswordDto(string? passwordDto)
    {
        return DomainWeb.Person.ValueObjects.PasswordValueObject.Create(passwordDto);
    }
}
