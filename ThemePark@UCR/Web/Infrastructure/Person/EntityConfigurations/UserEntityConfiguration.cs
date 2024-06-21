using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.EntityConfigurations;


// NOTE: If request must be changed, this and AplicationDb context must changed because
// here its where we make our data base request. This was made based on table User.Sql.
internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    //UserId
    //UserNickName
    //UserPasswordHash
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", schema: "ThemePark");

        builder.Property(u => u.IsActive);

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.UserNickName)
            .IsRequired()
            .HasMaxLength(UserNameValueObject.MaxLength)
            .HasConversion(
            // C# -> SQL conversion
            convertToProviderExpression: valueObject => valueObject.Value,
            // SQL -> C# conversion
            convertFromProviderExpression: nameString => UserNameValueObject.Create(nameString));
        
        builder.Property(u => u.UserPasswordHash)
            .IsRequired()
            .HasMaxLength(PasswordValueObject.MaxLength)
            .HasConversion(
            // C# -> SQL conversion
            convertToProviderExpression: valueObject => valueObject.Value,
            // SQL -> C# conversion
            convertFromProviderExpression: passwordString => PasswordValueObject.Create(passwordString));

        builder.Property(u => u.UserId)
          .HasConversion(
          convertToProviderExpression: guid => guid.ToString(),
          convertFromProviderExpression: idString => Guid.Parse(idString));

        // For PersonId as a Foreing key 
        builder.Property(u => u.PersonId)
               .IsRequired()
               .HasConversion(
                convertToProviderExpression: guid => guid.ToString(),
                convertFromProviderExpression: idString => Guid.Parse(idString));

        builder.HasOne<Persons>()
                   .WithOne(p => p.User)
                   .HasForeignKey<User>(u => u.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

       builder
            .HasMany(u => u.Roles)
            .WithMany(p => p.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UsersHaveRoles",
                j => j
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    //.HasConstraintName("FK_UsersHaveRoles_RoleId")
                    .OnDelete(DeleteBehavior.Cascade), // OnDelete Cascade should only occur when the reference goes to 1 user
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")  // Use UserId instead of UserNickName
                    //.HasConstraintName("FK_UsersHaveRoles_UserId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.ToTable("UsersHaveRoles", "ThemePark");
                    j.HasKey("UserId", "RoleId"); // Use UserId instead of UserNickName
                    j.IndexerProperty<Guid>("UserId").HasColumnType("varchar(255)"); // Assuming UserId is of type Guid
                    j.IndexerProperty<Guid>("RoleId").HasColumnType("varchar(255)"); // Assuming RoleId is of type Guid
                });
    }
}
