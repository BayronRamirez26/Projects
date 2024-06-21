using Riok.Mapperly.Abstractions;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;
using static System.Net.Mime.MediaTypeNames;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Person.Dtos;

[Mapper]
internal static partial class KiotaPersonDtoMapper
{
    internal static partial Persons ToEntity(DomainWeb.Person.Entities.Persons person);

    internal static UserNameValueObject ToValueObject(DomainWeb.Person.ValueObjects.UserNameValueObject username)
    {
        var output = new UserNameValueObject();
        output.Value = username.Value;
        return output;
    }

    internal static BirthDateValueObject ToValueObject(DomainWeb.Person.ValueObjects.BirthDateValueObject birthDateValue)
    {
        var output = new BirthDateValueObject();

        var dateOnly = birthDateValue.Value;

        var birthDateObject = new DateOnlyObject
        {
            Year = dateOnly.Value.Year,
            Month = dateOnly.Value.Month,
            Day = dateOnly.Value.Day
        };

        output.Value = birthDateObject;
        return output;
    }
 
    internal static PhoneValueObject ToValueObject(DomainWeb.Person.ValueObjects.PhoneValueObject phoneValue)
    {
        var output = new PhoneValueObject();
        output.Value = phoneValue.Value;
        return output;
    }

    internal static EmailValueObject ToValueObject(DomainWeb.Person.ValueObjects.EmailValueObject emailValue)
    {
        var output = new EmailValueObject();
        output.Value = emailValue.Value;
        return output;
    }

    internal static PasswordValueObject ToValueObject(DomainWeb.Person.ValueObjects.PasswordValueObject password)
    {
        var output = new PasswordValueObject();
        output.Value = password.Value;
        return output;
    }

    internal static CreatePersonRequest ToCreatePersonRequest(DomainWeb.Person.Entities.Persons person)
    {   
        string date = person.BirthDate.ToString();

        DateTime birthDate;
        DateOnlyObject dateOnlyObject = null;

        if (DateTime.TryParseExact(date, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out birthDate))
        {
            int year = birthDate.Year;
            int month = birthDate.Month;
            int day = birthDate.Day;

            dateOnlyObject = new DateOnlyObject
            {
                Day = day,
                DayOfWeek = (int)birthDate.DayOfWeek,
                Month = month,
                Year = year
            };        
        }

        return new CreatePersonRequest
        {
            FirstName = person.FirstName.Value,
            MiddleName = person.MiddleName?.Value,
            FirstLastName = person.FirstLastName.Value,
            SecondLastName = person.SecondLastName?.Value,
            BirthDate = dateOnlyObject,
            PhoneNumber = person.PhoneNumber?.Value,
            Email = person.Email?.Value
        };
    }

    internal static UpdatePersonRequest ToUpdatePersonRequest(DomainWeb.Person.Entities.Persons person)
    {
        string date = person.BirthDate.ToString();

        DateTime birthDate;
        DateOnlyObject dateOnlyObject = null;

        if (DateTime.TryParseExact(date, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out birthDate))
        {
            int year = birthDate.Year;
            int month = birthDate.Month;
            int day = birthDate.Day;

            dateOnlyObject = new DateOnlyObject
            {
                Day = day,
                DayOfWeek = (int)birthDate.DayOfWeek,
                Month = month,
                Year = year
            };
        }

        return new UpdatePersonRequest
        {
            PersonId = person.PersonId,
            FirstName = person.FirstName.Value,
            MiddleName = person.MiddleName?.Value,
            FirstLastName = person.FirstLastName.Value,
            SecondLastName = person.SecondLastName?.Value,
            BirthDate = dateOnlyObject,
            PhoneNumber = person.PhoneNumber?.Value,
            Email = person.Email?.Value
        };
    }
}
