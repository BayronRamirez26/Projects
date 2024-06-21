using System.ComponentModel.DataAnnotations;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;

public class LevelInfo
{  
    public Guid levelId { get; set; }

    public string? universityName { get; set; }

    public string? campusName { get; set; }

    public string? siteName { get; set; }

    public string? buildingAcronym { get; set; }

    public byte levelNumber { get; set; }

    [Range(1, 100, ErrorMessage = "El largo debe ser entre 1 y 100"),
        Required(ErrorMessage = "El largo debe ser asignado")]
    public double length { get; set; }

    [Range(1, 100, ErrorMessage = "El ancho debe ser entre 1 y 100"),
        Required(ErrorMessage = "El ancho debe ser asignado")]
    public double width { get; set; }

    [Range(1, 100, ErrorMessage = "La altura debe ser entre 1 y 100"),
        Required(ErrorMessage = "La altura debe ser asignada")]
    public double height { get; set; }

    //[Required(ErrorMessage = "El color de las paredes debe ser asignado")]
    public string? wallsColor { get; set; }

    //[Required(ErrorMessage = "El color del techo debe ser asignado")]
    public string? ceilingColor { get; set; }

    //[Required(ErrorMessage = "El color del suelo debe ser asignado")]
    public string? floorColor { get; set; }

    public byte learningSpaceCount { get; set; }

    public LevelInfo()
    {
        levelId = Guid.Empty;
        universityName = "";
        campusName = "";
        siteName = "";
        buildingAcronym = "";
        levelNumber = 0;
        length = 0;
        width = 0;
        height = 0;
        wallsColor = "#FFFFFF";
        ceilingColor = "#FFFFFF";
        floorColor = "#FFFFFF";
        learningSpaceCount = 0;
    }
}

