using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.EntityConfigurations;

internal class BOTemplateEntityConfiguration : IEntityTypeConfiguration<BOTemplate>
{
    public void Configure(EntityTypeBuilder<BOTemplate> builder)
    {
        // Select table
        builder.ToTable("BOTemplates", schema: "ThemePark");

        // The primary key of the entity
        builder.HasKey(b => b.TemplateId);

        // Other key candidates
        builder.HasAlternateKey(b => new
        {
            b.ObjectType,
            b.Plane,
            b.ObjectName
        });

        // Map all properties
        builder.Property(b => b.TemplateId)
            .HasColumnName("TemplateId")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: guidValueObject => GuidValueObject.Create(guidValueObject)
            );

        builder.Property(b => b.ObjectType)
            .HasColumnName("ObjectType")
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion   
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.Plane)
            .HasColumnName("Plane")
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.ObjectName)
            .HasColumnName("ObjectName")
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.DefaultLength)
            .HasColumnName("DefaultLength")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: sizeString => Size.Create(sizeString)
            );

        builder.Property(b => b.DefaultWidth)
            .HasColumnName("DefaultWidth")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: sizeString => Size.Create(sizeString)
            );

        builder.Property(b => b.DefaultHeight)
            .HasColumnName("DefaultHeight")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: sizeString => Size.Create(sizeString)
            );

        builder.Property(b => b.ColorAmount)
            .HasColumnName("ColorAmount")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: counterString => Counter.Create(counterString)
            );

        builder.Property(b => b.Color1Name)
            .HasColumnName("Color1Name")
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.DefaultColor1)
            .HasColumnName("DefaultColor1")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: colorString => Color.Create(colorString)
            );

        builder.Property(b => b.Color2Name)
            .HasColumnName("Color2Name")
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.DefaultColor2)
            .HasColumnName("DefaultColor2")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: colorString => Color.Create(colorString)
            );

        builder.Property(b => b.Color3Name)
            .HasColumnName("Color3Name")
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.DefaultColor3)
            .HasColumnName("DefaultColor3")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: colorString => Color.Create(colorString)
            );
    }
}
