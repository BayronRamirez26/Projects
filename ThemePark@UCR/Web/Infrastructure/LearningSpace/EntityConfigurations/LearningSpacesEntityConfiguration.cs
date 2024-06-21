using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.EntityConfiguration;

internal class LearningSpacesEntityConfiguration : IEntityTypeConfiguration<LearningSpaces>
{
    /// <summary>
    /// Configures the entity mapping for the LearningSpace entity.
    /// </summary>
    /// <param name="builder">The entity type builder used to configure the LearningSpace entity.</param>
    public void Configure(EntityTypeBuilder<LearningSpaces> builder)
    {
        // Select table
        builder.ToTable("LearningSpace", schema:"ThemePark");

        // TODO: Define Foreigh Keys if necessary

        // Define Keys
        builder.HasKey(u => new
        {
            //u.UniversityName,
            //u.CampusName,
            //u.SiteName,
            //u.BuildingAcronym,
            //u.LevelNumber,
            u.LearningSpaceId
        });

        
        // LearningSpaceName
        builder.Property(u => u.LearningSpaceName)
            .IsRequired()
            .HasMaxLength(ShortName.MaxLenght)
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: NameValue => NameValue.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => ShortName.Create(nameString));

        // Size X
        builder.Property(u => u.SizeX)
            .IsRequired()
            .HasColumnType("Float");


        // Size Y
        builder.Property(u => u.SizeY)
            .IsRequired()
            .HasColumnType("Float");

        // Size Z
        builder.Property(u => u.SizeZ)
            .IsRequired()
            .HasColumnType("Float");

        // FloorColor
        builder.Property(u => u.FloorColor)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: FloorColorValue => FloorColorValue.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => MediumName.Create(nameString));

        // CeilingColor
        builder.Property(u => u.CeilingColor)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: CeilingColorValue => CeilingColorValue.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => MediumName.Create(nameString));

        builder.Property(u => u.LevelId)
        .HasConversion(
        // C# -> SQL
        convertToProviderExpression: typeValue => typeValue.Value == Guid.Empty ? (Guid?)null : typeValue.Value,
        // SQL -> C#
        convertFromProviderExpression: guidId => guidId == null ? GuidWrapper.Create(Guid.Empty) : GuidWrapper.Create(guidId.Value));


        // WallsColor
        builder.Property(u => u.WallsColor)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: WallsColorValue => WallsColorValue.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => MediumName.Create(nameString));

        // type
        builder.Property(u => u.Type)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: GuidID => GuidWrapper.Create(GuidID));


        builder.Property(u => u.LearningSpaceId)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: GuidID => GuidWrapper.Create(GuidID));

        builder.Property(u => u.SizeX)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: SizeXValue => DoubleWrapper.Create(SizeXValue));

        builder.Property(u => u.SizeY)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: SizeYValue => DoubleWrapper.Create(SizeYValue));

        builder.Property(u => u.SizeZ)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: SizeZValue => DoubleWrapper.Create(SizeZValue));


    }
}

