using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.EntityConfiguration;

internal class Template_Has_ComponentsEntityConfiguration : IEntityTypeConfiguration<Template_Has_Components>
{
    /// <summary>
    /// Configures the entity mapping for the LearningSpace entity.
    /// </summary>
    /// <param name="builder">The entity type builder used to configure the LearningSpace entity.</param>
    public void Configure(EntityTypeBuilder<Template_Has_Components> builder)
    {
        // Select table
        builder.ToTable("Template_Has_Components", schema: "ThemePark");

        // TODO: Define Foreigh Keys if necessary

        // Define Keys
        builder.HasKey(u => new
        {
            u.Id
        });

        builder.Property(u => u.Id)
           .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: GuidID => GuidWrapper.Create(GuidID));

        builder.Property(u => u.Template)
           .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: GuidID => GuidWrapper.Create(GuidID));

        // LearningSpaceName
        builder.Property(u => u.Component_type)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: NameValue => NameValue.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => MediumName.Create(nameString));

        builder.Property(u => u.Template)
            .IsRequired();

        builder.Property(u => u.SizeX)
            .HasColumnType("Float")
            .HasConversion(
                // C# -> SQL
                convertToProviderExpression: sizeXValue => sizeXValue.Value,
                // SQL -> C#
                convertFromProviderExpression: SizeXValue => DoubleWrapper.Create(SizeXValue));

        builder.Property(u => u.SizeY)
            .HasColumnType("Float")
            .HasConversion(
                // C# -> SQL
                convertToProviderExpression: sizeYValue => sizeYValue.Value,
                // SQL -> C#
                convertFromProviderExpression: SizeYValue => DoubleWrapper.Create(SizeYValue));

        builder.Property(u => u.PositionX)
            .HasColumnType("Float")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionX => DoubleWrapper.Create(positionX)
            );

        builder.Property(u => u.PositionY)
            .HasColumnType("Float")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionY => DoubleWrapper.Create(positionY)
            );

        builder.Property(u => u.PositionZ)
            .HasColumnType("Float")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionZ => DoubleWrapper.Create(positionZ)
            );

        builder.Property(u => u.RotationX)
            .HasColumnType("Float")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: rotationX => DoubleWrapper.Create(rotationX)
            );

        builder.Property(u => u.RotationY)
         .HasColumnType("Float")
         .HasConversion(
             // C# -> SQL Conversion
             convertToProviderExpression: valueObject => valueObject.Value,
             // SQL -> C# conversion
             convertFromProviderExpression: rotationY => DoubleWrapper.Create(rotationY)
         );
    }
}

