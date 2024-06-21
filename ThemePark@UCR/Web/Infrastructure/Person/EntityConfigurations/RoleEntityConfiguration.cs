using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.EntityConfigurations;

internal class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role", schema: "ThemePark");

        builder.HasKey(u => u.RoleId);
        builder.Property(u => u.RoleId)
                .IsRequired()
                .HasColumnName("RoleId")
                .HasConversion(
                    guid => guid.ToString(),
                    idString => Guid.Parse(idString));

        builder.Property(u => u.RoleName)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
            // C# -> SQL conversion
            convertToProviderExpression: valueObject => valueObject.Value,
            // SQL -> C# conversion
            convertFromProviderExpression: nameString => MediumName.Create(nameString));

        builder
            .HasMany(u => u.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "RolesHavePermissions",
                j => j
                    .HasOne<Permission>()
                    .WithMany()
                    .HasForeignKey("PermissionId")                    
                    .OnDelete(DeleteBehavior.Cascade), // OnDelete Cascade should only occur when the reference goes to 1 user
                j => j
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")  // Use UserId instead of UserNickName                    
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.ToTable("RolesHavePermissions", "ThemePark");
                    j.HasKey("RoleId", "PermissionId"); // Use UserId instead of UserNickName
                    j.IndexerProperty<Guid>("RoleId").HasColumnType("varchar(255)"); // Assuming UserId is of type Guid
                    j.IndexerProperty<Guid>("PermissionId").HasColumnType("varchar(255)"); // Assuming RoleId is of type Guid
                });
    }
}