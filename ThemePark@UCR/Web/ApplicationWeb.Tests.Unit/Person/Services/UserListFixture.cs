using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Tests.Unit.Person.Services;

public class UserListFixture
{
    public IEnumerable<User> UserList { get; }
    public IEnumerable<User> GetUserList { get; }
    public UserListFixture()
    {
        UserList =
            [
            new User(
                Guid.NewGuid(),
                UserNameValueObject.Create("JohnDoe"),
                PasswordValueObject.Create("qwerty12"),
                true,
                Guid.NewGuid()
                ),
            new User(
                Guid.NewGuid(),
                UserNameValueObject.Create("DanielM"),
                PasswordValueObject.Create("contr12ds4"),
                true,
                Guid.NewGuid()
                ),
            new User(
                Guid.NewGuid(),
                UserNameValueObject.Create("MViquez"),
                PasswordValueObject.Create("a1b2c3"),
                true,
                Guid.NewGuid()
                ),
            ];
        GetUserList = UserList.ToList();
    }
}
