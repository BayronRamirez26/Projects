using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.EntityConfiguration;

internal class TemplatesEntityConfiguration : IEntityTypeConfiguration<Templates>
{
    /// <summary>
    /// Configures the entity mapping for the LearningSpace entity.
    /// </summary>
    /// <param name="builder">The entity type builder used to configure the LearningSpace entity.</param>
    public void Configure(EntityTypeBuilder<Templates> builder)
    {
        // Select table
        builder.ToTable("LearningSpace_Templates", schema: "ThemePark");

        // TODO: Define Foreigh Keys if necessary

        // Define Keys
        builder.HasKey(u => new
        {
            u.Id
        });


        // LearningSpaceName
        builder.Property(u => u.TemplateName)
            .IsRequired()
            .HasMaxLength(MediumName.MaxLenght)
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: NameValue => NameValue.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => MediumName.Create(nameString));

       

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
            .IsRequired();


        builder.Property(u => u.Id)
            .IsRequired();

        builder.Property(u => u.SizeX)
            .HasColumnType("Float")
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: SizeXValue => DoubleWrapper.Create(SizeXValue));

        builder.Property(u => u.SizeY)
            .HasColumnType("Float")
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: SizeYValue => DoubleWrapper.Create(SizeYValue));

        builder.Property(u => u.SizeZ)
            .HasColumnType("Float")
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: TypeValue => TypeValue.Value,
            // SQL -> C#
            convertFromProviderExpression: SizeZValue => DoubleWrapper.Create(SizeZValue));
    }
}

