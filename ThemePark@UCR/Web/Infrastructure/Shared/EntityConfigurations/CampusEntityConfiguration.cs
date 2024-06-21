using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Shared.EntityConfigurations;

internal class CampusEntityConfiguration : IEntityTypeConfiguration<Campus>
{
    /// <summary>
    /// Configures the entity mapping for the LearningSpace entity.
    /// </summary>
    /// <param name="builder">The entity type builder used to configure the LearningSpace entity.</param>
    public void Configure(EntityTypeBuilder<Campus> builder)
    {
        // Select table
        builder.ToTable("Campus", schema: "ThemePark");

        // TODO: Define Foreigh Keys if necessary

        // Define Keys
        builder.HasKey(u => new
        {
            u.UniversityName,
            u.CampusName

        });

        // Map all properties

        // University Name
        builder.Property(u => u.UniversityName)
            .IsRequired()
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: universityValue => universityValue.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => LongName.Create(nameString));

        // Campus Name
        builder.Property(u => u.CampusName)
            .IsRequired()
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: campusValue => campusValue.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => LongName.Create(nameString));
    }
}

