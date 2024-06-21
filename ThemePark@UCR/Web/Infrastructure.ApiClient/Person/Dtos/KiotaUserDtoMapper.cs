using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper]
internal static partial class KiotaUserDtoMapper
{
    internal static partial User ToEntity(DomainWeb.Person.Entities.User user);

    internal static UserNameValueObject ToValueObject(DomainWeb.Person.ValueObjects.UserNameValueObject username)
    {
        var output = new UserNameValueObject();
        output.Value = username.Value;
        return output;
    }

    internal static PasswordValueObject ToValueObject(DomainWeb.Person.ValueObjects.PasswordValueObject password)
    {
        var output = new PasswordValueObject();
        output.Value = password.Value;
        return output;
    }

    internal static CreateUserRequest ToCreateUserRequest(DomainWeb.Person.Entities.User user)
    {
        return new CreateUserRequest
        {
            UserNickName = user.UserNickName.Value,
            UserPasswordHash = user.UserPasswordHash.Value
        };
    }

}
