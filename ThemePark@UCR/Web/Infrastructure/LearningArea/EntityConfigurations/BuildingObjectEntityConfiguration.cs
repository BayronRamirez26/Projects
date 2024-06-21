using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.EntityConfigurations;

internal class BuildingObjectEntityConfiguration : IEntityTypeConfiguration<BuildingObject>
{
    public void Configure(EntityTypeBuilder<BuildingObject> builder)
    {
        // Select table
        builder.ToTable("BuildingObjects", schema: "ThemePark");

        // The primary key of the entity
        builder.HasKey(b => b.ObjectId)
            .HasName("PK_BuildingObjects");

        // Map all properties
        builder.Property(b => b.ObjectId)
            .HasColumnName("ObjectId")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: guidValueObject => GuidValueObject.Create(guidValueObject)
            );

        builder.Property(b => b.LevelId) // FK
            .HasColumnName("LevelId")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: guidValueObject => GuidValueObject.Create(guidValueObject)
            );

        builder.Property(b => b.ObjectType) // FK
            .HasColumnName("ObjectType")
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion   
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.Plane) // FK
            .HasColumnName("Plane")
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.ObjectName) // FK
            .HasColumnName("ObjectName")
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.Length)
            .HasColumnName("Length")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: size => Size.Create(size)
            );

        builder.Property(b => b.Width)
            .HasColumnName("Width")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: size => Size.Create(size)
            );

        builder.Property(b => b.Height)
            .HasColumnName("Height")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: size => Size.Create(size)
            );

        builder.Property(b => b.CenterX)
            .HasColumnName("CenterX")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: centerX => Coordinate.Create(centerX)
            );

        builder.Property(b => b.CenterY)
            .HasColumnName("CenterY")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: centerY => Coordinate.Create(centerY)
            );

        builder.Property(b => b.Rotation)
            .HasColumnName("Rotation")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: rotation => Angle.Create(rotation)
            );

        builder.Property(b => b.ColorAmount)
            .HasColumnName("ColorAmount")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: counter => Counter.Create(counter)
            );

        builder.Property(b => b.Color1)
            .HasColumnName("Color1")
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: color => Color.Create(color)
            );

        builder.Property(b => b.Color2)
            .HasColumnName("Color2")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: color => Color.Create(color)
            );

        builder.Property(b => b.Color3)
            .HasColumnName("Color3")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: color => Color.Create(color)
            );

        builder.Property(b => b.WallId)
            .HasColumnName("WallId")
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: counter => Counter.Create(counter)
            );

        builder.HasOne(b => b.Level)
            .WithMany()
            .HasForeignKey(b => b.LevelId)
            .HasConstraintName("FK_BuildingObject_belongs_to_Level")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
