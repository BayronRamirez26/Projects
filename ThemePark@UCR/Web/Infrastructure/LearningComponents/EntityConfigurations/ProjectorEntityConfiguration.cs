using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.EntityConfigurations;

internal class ProjectorEntityConfiguration : IEntityTypeConfiguration<Projector>
{
    public void Configure(EntityTypeBuilder<Projector> builder)
    {

        builder.ToTable("Projector", schema: "ThemePark");

        builder.HasBaseType<LearningComponent>();

        builder.Property(w => w.LearningComponentAssetId)
                .IsRequired();


        builder.Property(w => w.LearningComponentName)
              .IsRequired()
              .HasMaxLength(MediumName.MaxLenght)
              .HasConversion(
                convertToProviderExpression: typeValue => typeValue.Value,
                convertFromProviderExpression: nameString => MediumName.Create(nameString));

        builder.Property(w => w.PositionX)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionX => Coordinate.Create(positionX)
            );

        builder.Property(w => w.PositionY)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionY => Coordinate.Create(positionY)
            );

        builder.Property(w => w.PositionZ)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: positionZ => Coordinate.Create(positionZ)
            );

        builder.Property(w => w.SizeX)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: sizeX => Size.Create(sizeX)
            );

        builder.Property(w => w.SizeY)
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


        builder.Property(w => w.SizeX).HasColumnType("FLOAT");
        builder.Property(w => w.SizeY).HasColumnType("FLOAT");
        builder.Property(w => w.PositionX).HasColumnType("FLOAT");
        builder.Property(w => w.PositionY).HasColumnType("FLOAT");
        builder.Property(w => w.PositionZ).HasColumnType("FLOAT");
        builder.Property(w => w.RotationX).HasColumnType("FLOAT");
        builder.Property(w => w.RotationY).HasColumnType("FLOAT");
        builder.Property(w => w.LearningSpaceId).HasColumnType("UNIQUEIDENTIFIER");


    }
}
