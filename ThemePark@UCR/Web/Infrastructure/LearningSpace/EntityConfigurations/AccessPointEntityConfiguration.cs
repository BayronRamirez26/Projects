using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.EntityConfigurations;

internal class AccessPointEntityConfiguration : IEntityTypeConfiguration<AccessPoint>
{
    public void Configure(EntityTypeBuilder<AccessPoint> builder)
    {
        // Select table
        builder.ToTable("AccessPoint", schema: "ThemePark");

        // TODO: Define Foreigh Keys if necessary

        // Define Keys
        builder.HasKey(u => new
        {
            u.AccessPointId
        });

        // Map all properties

        // AccessPointId
        builder.Property(u => u.AccessPointId)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: GuidID => GuidWrapper.Create(GuidID));

        // LearningSpaceId
        builder.Property(u => u.LearningSpaceId)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: GuidID => GuidWrapper.Create(GuidID));

        // LevelId
        builder.Property(u => u.LevelId)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: GuidID => GuidWrapper.Create(GuidID));

        // Size X
        builder.Property(u => u.CoordX);

        // Size Y
        builder.Property(u => u.CoordY);

        // Size Z
        builder.Property(u => u.CoordZ);

        // Rotation X
        builder.Property(u => u.RotationX);

        // Rotation Y
        builder.Property(u => u.RotationY);

    }
}

