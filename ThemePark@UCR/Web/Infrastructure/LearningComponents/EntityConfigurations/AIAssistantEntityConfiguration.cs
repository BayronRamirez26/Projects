using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.EntityConfigurations;

internal class AIAssistantEntityConfiguration : IEntityTypeConfiguration<AIAssistant>
{
    public void Configure(EntityTypeBuilder<AIAssistant> builder)
    {
        builder.ToTable("IAAssistant", schema: "ThemePark");

        builder.Property(a => a.LearningComponentAssetId)
                .IsRequired();

        builder.Property(a => a.LearningComponentName)
              .IsRequired()
              .HasMaxLength(MediumName.MaxLenght)
              .HasConversion(
                convertToProviderExpression:  typeValue => typeValue.Value,
                convertFromProviderExpression:  nameString => MediumName.Create(nameString));

        builder.Property(a => a.PositionX)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionX => Coordinate.Create(positionX)
            );

        builder.Property(a => a.PositionY)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionY => Coordinate.Create(positionY)
            );

        builder.Property(a => a.PositionZ)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionZ => Coordinate.Create(positionZ)
            );

        builder.Property(a => a.SizeX)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: sizeX => Size.Create(sizeX)
            );

        builder.Property(a => a.SizeY)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: sizeY => Size.Create(sizeY)
            );

        builder.Property(w => w.RotationX)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: rotationX => Coordinate.Create(rotationX)
            );

        builder.Property(w => w.RotationY)
         .IsRequired()
         .HasConversion(
             // C# -> SQL Conversion
             convertToProviderExpression: valueObject => valueObject.Value,
             // SQL -> C# conversion
             convertFromProviderExpression: rotationY => Coordinate.Create(rotationY)
         );


        builder.Property(w => w.LearningSpaceId)
           .IsRequired()
           .HasConversion(
           // C# -> SQL
           convertToProviderExpression: TypeValue => TypeValue.Value,
           // SQL -> C#
           convertFromProviderExpression: GuidID => GuidWrapper.Create(GuidID));

        builder.Property(a => a.SizeX).HasColumnType("FLOAT");
        builder.Property(a => a.SizeY).HasColumnType("FLOAT");
        builder.Property(a => a.PositionX).HasColumnType("FLOAT");
        builder.Property(a => a.PositionY).HasColumnType("FLOAT");
        builder.Property(a => a.PositionZ).HasColumnType("FLOAT");
        builder.Property(w => w.RotationX).HasColumnType("FLOAT");
        builder.Property(w => w.RotationY).HasColumnType("FLOAT");
        builder.Property(w => w.LearningSpaceId).HasColumnType("UNIQUEIDENTIFIER");

    }
}
