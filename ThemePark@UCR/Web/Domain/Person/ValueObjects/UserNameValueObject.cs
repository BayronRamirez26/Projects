using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

public class UserNameValueObject
{
    public string Value { get;}
    public static readonly char[] IllegalCharacters = ['/', '#', '!', '@'];
    public const int MaxLength = 255;
    public static readonly UserNameValueObject Invalid = new(string.Empty);

  
    public UserNameValueObject(string value) { Value = value;}
    public static bool TryCreate(string? value, out UserNameValueObject userNickName)
    {
        //Run validation
        userNickName = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }
        if (value.IndexOfAny(IllegalCharacters) != -1)
        {
            return false;
        }

        if (value.Length > MaxLength)
        {
            return false;
        }

        //If validation passed, then return true and assign the name to the out parameter.
        //Otherwise, return false
        userNickName = new UserNameValueObject(value);
        return true;
    }

    public static UserNameValueObject Create(string userNameValueObjectString)
    {
        var result = TryCreate(userNameValueObjectString, out var userNickName);
        if (!result)
        {
            throw new ArgumentException("Invalid name.");
        }
        Console.WriteLine(userNickName.Value);
        return userNickName;
    }

}
