using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

/// <summary>
/// This represents the Person entity in our system.
/// It contains the values related to a person
/// </summary>
/// <remarks>
/// A Person Has users that have a type
/// </remarks>
public class Persons
{
    /// <summary>
    /// This is the main constructor for the Person entity
    /// </summary>
    /// <param name="personId">Person's unique ID.</param>
    /// <param name="firstName">Person's first name.</param>
    /// <param name="middleName">Person's middle name.</param>
    /// <param name="firstLastName">Person's 1st last name</param>
    /// <param name="secondLastName">Person's 2nd last name</param>
    /// <param name="birthDate">Person's date of birth.</param>
    /// <param name="phoneNumber">Person's phone number.</param>
    /// <param name="email">Person's email.</param>

    public Persons(
        //value object
        Guid personId,
        UserNameValueObject firstName,
        UserNameValueObject middleName,
        UserNameValueObject firstLastName,
        UserNameValueObject secondLastName,
        BirthDateValueObject birthDate,
        PhoneValueObject phoneNumber,
        EmailValueObject email)
    {
        PersonId = personId;
        FirstName = firstName;
        MiddleName = middleName;
        FirstLastName = firstLastName;
        SecondLastName = secondLastName;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        Email = email;
    }


    public Persons()
    {
        PersonId = Guid.NewGuid();
    }

    /// <summary>
    /// Person's unique ID.
    /// </summary>
    public Guid PersonId { get; set; }

    /// <summary>
    /// Person's First Name.
    /// </summary>
    public UserNameValueObject FirstName { get; set; }

    /// <summary>
    /// Person's Middle Name.
    /// </summary>
    public UserNameValueObject MiddleName { get; set; }

    /// <summary>
    /// Person's First Last Name.
    /// </summary>
    public UserNameValueObject FirstLastName { get; set; }

    /// <summary>
    /// Person's Second Last Name.
    /// </summary>
    public UserNameValueObject SecondLastName { get; set; }

    /// <summary>
    /// Person's Birth Date
    /// </summary>
    public BirthDateValueObject BirthDate { get; set; }

    /// <summary>
    /// Person's Phone Number.
    /// </summary>
    public PhoneValueObject PhoneNumber { get; set; }

    /// <summary>
    /// Person's Email.
    /// </summary>
    public EmailValueObject Email { get; set; }

    public User? User { get; set; } // Reference navigation property to dependent one to one 

    //public Student Student { get; set; }

   // public Professor Professor { get; set; }
}