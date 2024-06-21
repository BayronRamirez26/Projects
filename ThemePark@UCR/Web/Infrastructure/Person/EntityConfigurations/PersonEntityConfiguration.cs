using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.EntityConfigurations;

internal class PersonsEntityConfiguration : IEntityTypeConfiguration<Persons>
{
    public void Configure(EntityTypeBuilder<Persons> builder)
    {
        builder.ToTable("Person", schema: "ThemePark");
        builder.HasKey(p => p.PersonId);

        // For FirstName atribute
        builder.Property(p => p.FirstName)
             .IsRequired()
             .HasMaxLength(UserNameValueObject.MaxLength)
             .HasConversion(
                convertToProviderExpression: firstNameValueObject => firstNameValueObject.Value,
                convertFromProviderExpression: firstNameString => UserNameValueObject.Create(firstNameString));

        // For middleName atribute
        builder.Property(p => p.MiddleName)
            .HasMaxLength(UserNameValueObject.MaxLength)
            .HasConversion(
                convertToProviderExpression: middleNameValueObject => middleNameValueObject.Value,
                convertFromProviderExpression: middleNameString => UserNameValueObject.Create(middleNameString));

        // For FirstLastName atribute
        builder.Property(p => p.FirstLastName)
            .IsRequired()
            .HasMaxLength(UserNameValueObject.MaxLength)
            .HasConversion(
                convertToProviderExpression: firstLastNameValueObject => firstLastNameValueObject.Value,
                convertFromProviderExpression: firstLastNameString => UserNameValueObject.Create(firstLastNameString));

        // For SecondLastName atribute
        builder.Property(p => p.SecondLastName)
                .HasMaxLength(UserNameValueObject.MaxLength)
                .HasConversion(
                    convertToProviderExpression: secondLastNameValueObject => secondLastNameValueObject.Value,
                    convertFromProviderExpression: secondLastNameString => UserNameValueObject.Create(secondLastNameString));

        // For BirthDate atribute
        builder.Property(p => p.BirthDate)
               .HasConversion(
                    convertToProviderExpression: birthDateValueObject => birthDateValueObject.Value,
                    convertFromProviderExpression: birthDateString => BirthDateValueObject.Create(birthDateString));

        //For PhoneNumber atribute
        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(PhoneValueObject.MaxLength)
            .HasConversion(
                convertToProviderExpression: phoneNumberValueObject => phoneNumberValueObject.Value,
                convertFromProviderExpression: phoneNumberString => PhoneValueObject.Create(phoneNumberString));

        // For Email atribute
        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(320) //Esoecificar en valueObject el MaxLenght
                               //.HasMaxLength(EmailValueObject.MaxLength) 
            .HasConversion(
                convertToProviderExpression: emailValueObject => emailValueObject.Value,
                convertFromProviderExpression: emailString => EmailValueObject.Create(emailString));

        builder.Property(p => p.PersonId)
            .IsRequired()
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: guid => guid.ToString(),
                // SQL -> C# conversion
                convertFromProviderExpression: idString => Guid.Parse(idString));


    }
}


