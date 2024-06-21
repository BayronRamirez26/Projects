using System.Text.Json;
using System.Text.Json.Serialization;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

public class User
{
    public User(
        Guid userId,
        UserNameValueObject userNickName,
        PasswordValueObject userPasswordHash,
        bool isActive,
        Guid personId)
    {
        UserId = userId;
        UserNickName = userNickName;
        UserPasswordHash = userPasswordHash;
        IsActive = isActive;
        PersonId = personId;
        Roles = new List<Role>();
        //Token = new String();
    }
    public Guid PersonId { get; set; } // Required foreingn key property
    public Guid UserId { get; set; }
    public UserNameValueObject UserNickName { get; set; }
    public PasswordValueObject UserPasswordHash { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Role> Roles { get; set; }
    public string Token { get; set; }

}

public class UserState
{
    public User? SelectedUser { get; set; }
}


