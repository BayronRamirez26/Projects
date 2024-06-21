using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.Fixtures;

public class UserValueObjectsFixture
{
    private const string kUserNickNameValue = "JohnDoe";
    private const string kUserPasswordHashValue = "qwerty123";
    
    public UserNameValueObject UserNickName { get; private set; }
    public PasswordValueObject UserPasswordHash { get; private set; }

    public UserValueObjectsFixture()
    {
        UserNickName = UserNameValueObject.Create(kUserNickNameValue);
        UserPasswordHash = PasswordValueObject.Create(kUserPasswordHashValue);
    }
}
