using BlazorStrap;
using BlazorStrap.V5;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ModifyLevel
{
    BSModal? modal;
    private LevelInfo level { get; set; } = new LevelInfo();
    private IEnumerable<Level> existingLevels { get; set; } = new List<Level>();
    private List<Tuple<DomainWeb.Shared.ValueObjects.Counter, DomainWeb.Shared.ValueObjects.Counter>> levelsBeforeAfter { get; set; } = new List<Tuple<DomainWeb.Shared.ValueObjects.Counter, DomainWeb.Shared.ValueObjects.Counter>>();
    private static List<DropZone> _zones = new() { new() { Name = "Arrastre y suelte los niveles" }, };
    private List<DropZoneItem> _items = new();
    public string modalContent = "";
    public string modalTitle = "";
    public string colorStatus = "";
    public string messageButton1 = "";
    public string messageButton2 = "";
    public bool success = false;
    private List<LevelInfo> existingLevelsDto { get; set; } = new List<LevelInfo>();

    private bool initialized = false;
    private bool updatePermission = false;

    private void OnReset(IBSForm bSForm)
    {
        bSForm.Reset();
    }
}
