using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.EntityConfigurations;

internal class PermissionEntityConfiguration: IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission", schema: "ThemePark");

        builder.HasKey(u => u.PermissionId);

        builder.Property(u => u.PermissionId)
                .IsRequired()
                .HasColumnName("PermissionId")
                .HasConversion(
                    guid => guid.ToString(),
                    idString => Guid.Parse(idString));

        builder.Property(u => u.PermissionDescription)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
            // C# -> SQL conversion
            convertToProviderExpression: valueObject => valueObject.Value,
            // SQL -> C# conversion
            convertFromProviderExpression: nameString => MediumName.Create(nameString));
    }
}
