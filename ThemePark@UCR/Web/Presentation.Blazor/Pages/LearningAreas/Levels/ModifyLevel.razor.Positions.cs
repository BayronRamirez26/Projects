using MudBlazor;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ModifyLevel
{
    private void ItemUpdated(MudItemDropInfo<DropZoneItem> dropItem)
    {
        // Get the index of the item in the original list
        int oldIndex = _items.IndexOf(dropItem.Item);

        // Update the zone name based on the dropzone identifier
        dropItem.Item.Zone.Name = dropItem.DropzoneIdentifier;

        // Remove the item from the original list
        _items.RemoveAt(oldIndex);

        // Insert the item at the new position based on the dropzone index
        _items.Insert(dropItem.IndexInZone, dropItem.Item);

        // Notify UI about changes
        StateHasChanged();
    }

    private void AddExistingLevelsToItems()
    {
        // Name format: Nivel levelNumber (length x width x height)
        _items = existingLevels.Select(l => new DropZoneItem
        {
            Zone = _zones[0],
            Name = $"Nivel {l.LevelNumber.Value} ({l.SizeX.Value} m x {l.SizeY.Value} m x {l.SizeZ.Value} m)",
            OriginalLevelNumber = l.LevelNumber.Value,
        }).ToList();
    }

    private void SetupCurrentLevel()
    {
        // Get the level from existing levels that corresponds to the current level number
        var currentLevel = existingLevels.FirstOrDefault(l => l.LevelNumber.Value == level.levelNumber);
        if (currentLevel == null)
        {
            return;
        }

        level.levelId = currentLevel.LevelId.Value;
        level.length = currentLevel.SizeX.Value;
        level.width = currentLevel.SizeY.Value;
        level.height = currentLevel.SizeZ.Value;
        level.wallsColor = currentLevel.WallsColor.Value;
        level.ceilingColor = currentLevel.CeilingColor.Value;
        level.floorColor = currentLevel.FloorColor.Value;
        level.learningSpaceCount = currentLevel.LearningSpaceCount.Value;

        // Change Name in _items
        var item = _items.FirstOrDefault(i => i.OriginalLevelNumber == level.levelNumber);
        if (item != null)
        {
            item.Name = "Nivel Actual";
        }
    }
}
