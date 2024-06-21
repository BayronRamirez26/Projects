using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper]

internal static partial class PersonDtoMapper
{   
    internal static partial DomainWeb.Person.Entities.Persons ToEntity(PersonDto personsDto); // Del Personde Entity al Person de Kiota


    internal static DomainWeb.Person.ValueObjects.UserNameValueObject ToUserNameDto(string? usernameDto)
    {
        return DomainWeb.Person.ValueObjects.UserNameValueObject.Create(usernameDto);
    }

    internal static DomainWeb.Person.ValueObjects.BirthDateValueObject ToBirthDateDto(string? birthDateDto)
    {
        if (string.IsNullOrEmpty(birthDateDto))
        {
            return null; // or throw an exception, depending on your requirements
        }

        var dateParts = birthDateDto.Split('-');
        if (dateParts.Length != 3)
        {
            throw new FormatException("Invalid birth date format. Expected dd-MM-YYYY.");
        }

        var day = int.Parse(dateParts[0]);
        var month = int.Parse(dateParts[1]);
        var year = int.Parse(dateParts[2]);

        var dateOnly = new DateOnly(year, month, day);
        return DomainWeb.Person.ValueObjects.BirthDateValueObject.Create(dateOnly);
    }

    internal static DomainWeb.Person.ValueObjects.PhoneValueObject ToPhoneDto(string? phoneDto)
    {
        return DomainWeb.Person.ValueObjects.PhoneValueObject.Create(phoneDto);
    }

    internal static DomainWeb.Person.ValueObjects.EmailValueObject ToemailDto(string? emailDto)
    {
        return DomainWeb.Person.ValueObjects.EmailValueObject.Create(emailDto);
    }

    internal static DomainWeb.Person.ValueObjects.PasswordValueObject ToPasswordDto(string? passwordDto)
    {
        return DomainWeb.Person.ValueObjects.PasswordValueObject.Create(passwordDto);
    }


}
