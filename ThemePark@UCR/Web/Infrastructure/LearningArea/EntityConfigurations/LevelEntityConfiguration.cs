using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.EntityConfigurations;

/// US: PIIB2401G1-93 CAD-CRL-02 List building levels
/// Task: PIIB2401G1-315 Create Level entity configuration on Infrastructure
/// Christopher Viquez Aguilar
/// Daniel Van der Laat Velez
/// Francisco Ulate
internal class LevelEntityConfiguration : IEntityTypeConfiguration<Level>
{
    public void Configure(EntityTypeBuilder<Level> builder)
    {
        // Select table
        builder.ToTable("Level", schema: "ThemePark");

        // The primary key of the entity
        builder.HasKey(l => l.LevelId);

        // Map all properties
        // PKs
        builder.Property(l => l.LevelId)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: guidValueObject => GuidValueObject.Create(guidValueObject)
            );

        builder.HasOne(l => l.Building)
            .WithMany(b => b.Levels)
            .HasForeignKey(l => l.BuildingId)
            .HasPrincipalKey(b => b.BuildingId)
            .OnDelete(DeleteBehavior.Cascade);

        // Other properties

        builder.Property(l => l.UniversityName)
            .IsRequired()
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: longNameString => LongName.Create(longNameString)
            );

        builder.Property(l => l.CampusName)
            .IsRequired()
            .HasMaxLength(LongName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: longNameString => LongName.Create(longNameString)
            );

        builder.Property(l => l.SiteName)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: mediumNameString => MediumName.Create(mediumNameString)
            );

        builder.Property(l => l.BuildingAcronym)
            .IsRequired()
            .HasMaxLength(ShortName.MaxLenght)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: shortNameString => ShortName.Create(shortNameString)
            );


        builder.Property(l => l.LevelNumber)
             .IsRequired()
             .HasMaxLength(Counter.MaxValue)
             .HasConversion(
                 // C# -> SQL Conversion
                 convertToProviderExpression: valueObject => valueObject.Value,
                 // SQL -> C# conversion
                 convertFromProviderExpression: counter => Counter.Create(counter)
             );

        
        builder.Property(l => l.SizeX)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: size => Size.Create(size)
            );


        builder.Property(l => l.SizeY)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: size => Size.Create(size)
            );


        builder.Property(l => l.SizeZ)
            .IsRequired()
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: sizeZ => Size.Create(sizeZ)
            );

        builder.Property(l => l.WallsColor)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: color => Color.Create(color)
            );

        builder.Property(l => l.FloorColor)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: color => Color.Create(color)
            );

        builder.Property(l => l.CeilingColor)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: color => Color.Create(color)
            );

        builder.Property(l => l.LearningSpaceCount)
            .IsRequired(false)
            .HasMaxLength(Counter.MaxValue)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: counter => Counter.Create(counter)
            );

        builder.Property(l => l.BuildingId)
            .IsRequired(false)
            .HasConversion(
                // C# -> SQL Conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: guidValueObject => GuidValueObject.Create(guidValueObject)
            );

        builder
            .InsertUsingStoredProcedure(
                "AddLevel",
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasParameter(l => l.LevelId);
                    storedProcedureBuilder.HasParameter(l => l.UniversityName);
                    storedProcedureBuilder.HasParameter(l => l.CampusName);
                    storedProcedureBuilder.HasParameter(l => l.SiteName);
                    storedProcedureBuilder.HasParameter(l => l.BuildingAcronym);
                    storedProcedureBuilder.HasParameter(l => l.LevelNumber);
                    storedProcedureBuilder.HasParameter(l => l.SizeX);
                    storedProcedureBuilder.HasParameter(l => l.SizeY);
                    storedProcedureBuilder.HasParameter(l => l.SizeZ);
                    storedProcedureBuilder.HasParameter(l => l.WallsColor);
                    storedProcedureBuilder.HasParameter(l => l.FloorColor);
                    storedProcedureBuilder.HasParameter(l => l.CeilingColor);
                    storedProcedureBuilder.HasParameter(l => l.LearningSpaceCount);
                    storedProcedureBuilder.HasParameter(l => l.BuildingId);
                })
            .UpdateUsingStoredProcedure(
                "UpdateLevel",
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasOriginalValueParameter(l => l.LevelId);
                    storedProcedureBuilder.HasParameter(l => l.UniversityName);
                    storedProcedureBuilder.HasParameter(l => l.CampusName);
                    storedProcedureBuilder.HasParameter(l => l.SiteName);
                    storedProcedureBuilder.HasParameter(l => l.BuildingAcronym);
                    storedProcedureBuilder.HasParameter(l => l.LevelNumber);
                    storedProcedureBuilder.HasParameter(l => l.SizeX);
                    storedProcedureBuilder.HasParameter(l => l.SizeY);
                    storedProcedureBuilder.HasParameter(l => l.SizeZ);
                    storedProcedureBuilder.HasParameter(l => l.WallsColor);
                    storedProcedureBuilder.HasParameter(l => l.FloorColor);
                    storedProcedureBuilder.HasParameter(l => l.CeilingColor);
                    storedProcedureBuilder.HasParameter(l => l.LearningSpaceCount);
                    storedProcedureBuilder.HasOriginalValueParameter(l => l.BuildingId);
                })
            .DeleteUsingStoredProcedure(
                "DeleteLevel",
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasOriginalValueParameter(l => l.LevelId);
                });
    }
}
