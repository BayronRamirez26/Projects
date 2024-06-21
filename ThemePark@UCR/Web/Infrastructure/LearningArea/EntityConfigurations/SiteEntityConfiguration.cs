using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.EntityConfigurations;

internal class SiteEntityConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        builder.ToTable("Site", schema: "ThemePark");

        builder.HasKey(s => new 
        { 
            s.UniversityName, 
            s.CampusName, 
            s.SiteName 
        });

        // Map all properties
        builder.Property(s => s.UniversityName)
            .IsRequired()
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion   
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: longNameString => LongName.Create(longNameString)
            );

        builder.Property(s => s.CampusName)
            .IsRequired()
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: longNameString => LongName.Create(longNameString)
            );

        builder.Property(s => s.SiteName)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(s => s.SizeX)
            .HasColumnName("SizeX")
            .IsRequired()
            .HasConversion(
                // C# -> SQL
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C#
                convertFromProviderExpression: sizeDouble => Size.Create(sizeDouble)
            );

        builder.Property(s => s.SizeY)
            .HasColumnName("SizeY")
            .IsRequired()
            .HasConversion(
                // C# -> SQL
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C#
                convertFromProviderExpression: sizeDouble => Size.Create(sizeDouble)
            );
    }
}
