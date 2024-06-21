using Microsoft.AspNetCore.Components.Forms;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class AddLevel
{
    private void FillLevelsBeforeAfter()
    {
        levelsBeforeAfter.Clear();
        foreach (var item in _items)
        {
            int index = _items.IndexOf(item);
            var levelNumberBefore = DomainWeb.Shared.ValueObjects.Counter.Create(item.OriginalLevelNumber);
            var levelNumberAfter = DomainWeb.Shared.ValueObjects.Counter.Create((byte)(_items.Count - index));
            levelsBeforeAfter.Add(new Tuple<DomainWeb.Shared.ValueObjects.Counter, DomainWeb.Shared.ValueObjects.Counter>(levelNumberBefore, levelNumberAfter));
        }
    }
    private IEnumerable<Level?> getUpdatedLevels()
    {
        FillLevelsBeforeAfter();

        // Create updated levels list with new level number
        IEnumerable<Level?> updatedLevels = _items.Select(item =>
        {
            var currentLevelDto = existingLevelsDto.FirstOrDefault(l => l.levelNumber == item.OriginalLevelNumber);
            if (currentLevelDto == null)
            {
                return null;
            }

            // Get the new level number
            byte newLevelNumber = levelsBeforeAfter
                .FirstOrDefault(
                    l => l.Item1.Value == currentLevelDto.levelNumber)
                .Item2.Value;

            // Create updated level
            Level updatedLevel = new Level(
                GuidValueObject.Create(currentLevelDto.levelId),
                LongName.Create(currentLevelDto.universityName),
                LongName.Create(currentLevelDto.campusName),
                MediumName.Create(currentLevelDto.siteName),
                ShortName.Create(currentLevelDto.buildingAcronym),
                DomainWeb.Shared.ValueObjects.Counter.Create(newLevelNumber),
                DomainWeb.Shared.ValueObjects.Size.Create(currentLevelDto.length),
                DomainWeb.Shared.ValueObjects.Size.Create(currentLevelDto.width),
                DomainWeb.Shared.ValueObjects.Size.Create(currentLevelDto.height),
                Color.Create(currentLevelDto.wallsColor),
                Color.Create(currentLevelDto.floorColor),
                Color.Create(currentLevelDto.ceilingColor),
                DomainWeb.Shared.ValueObjects.Counter.Create(currentLevelDto.learningSpaceCount)
            );

            return updatedLevel;
        });

        // Remove null values from the updated levels list
        updatedLevels = updatedLevels.Where(l => l != null);

        return updatedLevels;
    }
}
