using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.EntityConfigurations;

internal class BuildingEntityConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        // Select table
        builder.ToTable("Building", schema: "ThemePark");

        // The primary key of the entity
        builder.HasKey(b => b.BuildingId);

        // Map all properties
        builder.Property(b => b.BuildingId)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: guidValueObject => GuidValueObject.Create(guidValueObject)
            );

        builder.Property(b => b.UniversityName)
            .IsRequired()
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion   
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: longNameString => LongName.Create(longNameString)
            );

        builder.Property(b => b.CampusName)
            .IsRequired()
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: longNameString => LongName.Create(longNameString)
            );

        builder.Property(b => b.SiteName)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(b => b.BuildingAcronym)
            .IsRequired()
            .HasMaxLength(ShortName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: shortNameString => ShortName.Create(shortNameString)
            );

        builder.Property(b => b.BuildingName)
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: longNameString => LongName.Create(longNameString)
            );

        builder.Property(b => b.CenterX)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: centerX => Coordinate.Create(centerX)
            );

        builder.Property(b => b.CenterY)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: centerX => Coordinate.Create(centerX)
            );

        builder.Property(b => b.Length)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: length => Size.Create(length)
            );

        builder.Property(b => b.Width)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: width => Size.Create(width)
            );

        builder.Property(b => b.Rotation)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: rotation => Angle.Create(rotation)
            );

        builder.Property(b => b.WallsColor)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: wallsColor => Color.Create(wallsColor)
            );

        builder.Property(b => b.RoofColor)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: roofColor => Color.Create(roofColor)
            );

        builder.Property(b => b.Height)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: height => Size.Create(height)
            );

        builder.Property(b => b.LevelCount)
            .HasMaxLength(Counter.MaxValue)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: levelCount => Counter.Create(levelCount)
            );

        builder
            .InsertUsingStoredProcedure(
                "CreateBuilding",
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasParameter(b => b.BuildingId);
                    storedProcedureBuilder.HasParameter(b => b.UniversityName);
                    storedProcedureBuilder.HasParameter(b => b.CampusName);
                    storedProcedureBuilder.HasParameter(b => b.SiteName);
                    storedProcedureBuilder.HasParameter(b => b.BuildingAcronym);
                    storedProcedureBuilder.HasParameter(b => b.BuildingName);
                    storedProcedureBuilder.HasParameter(b => b.CenterX);
                    storedProcedureBuilder.HasParameter(b => b.CenterY);
                    storedProcedureBuilder.HasParameter(b => b.Length);
                    storedProcedureBuilder.HasParameter(b => b.Width);
                    storedProcedureBuilder.HasParameter(b => b.Rotation);
                    storedProcedureBuilder.HasParameter(b => b.WallsColor);
                    storedProcedureBuilder.HasParameter(b => b.RoofColor);
                    storedProcedureBuilder.HasParameter(b => b.Height);
                    storedProcedureBuilder.HasParameter(b => b.LevelCount);
                })
            .UpdateUsingStoredProcedure(
                "UpdateBuilding",
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasOriginalValueParameter(b => b.BuildingId);
                    storedProcedureBuilder.HasParameter(b => b.UniversityName);
                    storedProcedureBuilder.HasParameter(b => b.CampusName);
                    storedProcedureBuilder.HasParameter(b => b.SiteName);
                    storedProcedureBuilder.HasParameter(b => b.BuildingAcronym);
                    storedProcedureBuilder.HasParameter(b => b.BuildingName);
                    storedProcedureBuilder.HasParameter(b => b.CenterX);
                    storedProcedureBuilder.HasParameter(b => b.CenterY);
                    storedProcedureBuilder.HasParameter(b => b.Length);
                    storedProcedureBuilder.HasParameter(b => b.Width);
                    storedProcedureBuilder.HasParameter(b => b.Rotation);
                    storedProcedureBuilder.HasParameter(b => b.WallsColor);
                    storedProcedureBuilder.HasParameter(b => b.RoofColor);
                    storedProcedureBuilder.HasParameter(b => b.Height);
                    storedProcedureBuilder.HasParameter(b => b.LevelCount);
                })
            .DeleteUsingStoredProcedure(
                "DeleteBuilding",
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasOriginalValueParameter(b => b.BuildingId);
                });
    }
}
