using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.EntityConfigurations;

internal class LearningSpaceTypeEntityConfiguration : IEntityTypeConfiguration<LSType>
{
    public void Configure(EntityTypeBuilder<LSType> builder)
    {
        builder.ToTable("LearningSpaceType", schema: "ThemePark");

        builder.HasKey(l => new
        {
            l.Id
        });

        builder.Property(l => l.Id)
            .IsRequired();

        builder.Property(l => l.Name)
            .IsRequired()
            .HasConversion(
            // C# -> SQL
            convertToProviderExpression: Name => Name.Value,
            // SQL -> C#
            convertFromProviderExpression: nameString => MediumName.Create(nameString));
    }
}
