using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Buildings;

public class BuildingInfo
{
    public int Rotation { get; set; }
    public string? BuildingName { get; set; }

    [Range(1, 700, ErrorMessage = "La coordenada X debe ser mayor a 0 y menor a 700"),
    Required(ErrorMessage = "La coordenada X debe ser asignada")]
    public int CenterX { get; set; }

    [Range(1, 700, ErrorMessage = "La coordenada Y debe ser mayor a 0 y menor a 700"),
    Required(ErrorMessage = "La coordenada Y debe ser asignada")]
    public int CenterY { get; set; }

    // The size has to be greater than 0
    [Required(ErrorMessage = "El largo debe ser asignado"),
    Range(1, 700, ErrorMessage = "El largo debe ser mayor a 0")
    ]
    public int Length { get; set; }

    [Required(ErrorMessage = "El ancho debe ser asignado"),
    Range(1, 700, ErrorMessage = "El ancho debe ser mayor a 0")
    ]
    public int Width { get; set; }

    [Required(ErrorMessage = "El nombre de la universidad debe ser asignado")]
    public string? UniversityName { get; set; }

    [Required(ErrorMessage = "El nombre del campus debe ser asignado")]
    public string? CampusName { get; set; }

    [Required(ErrorMessage = "El nombre de la finca debe ser asignado")]
    public string? SiteName { get; set; }

    [
        Required(ErrorMessage = "El acrónimo del edificio debe ser asignado"),
        MaxLength(ShortName.MaxLenght, ErrorMessage = "El acrónimo del edificio no puede tener más de 10 caracteres")
    ]
    public string? BuildingAcronym { get; set; }

    //[Required(ErrorMessage = "El color de las paredes debe ser asignado")]
    public string? WallsColor { get; set; }

    //[Required(ErrorMessage = "El color del techo debe ser asignado")]
    public string? RoofColor { get; set; }

    public Guid BuildingId { get; set; }

    // default constructor
    public BuildingInfo()
    {
        this.CenterX = 0;
        this.CenterY = 0;
        this.Length = 0;
        this.Width = 0;
        this.Rotation = 0;
        this.BuildingName = null;
        this.UniversityName = "";
        this.CampusName = "";
        this.SiteName = "";
        this.BuildingAcronym = null;
        this.WallsColor = "#FFFFFF";
        this.RoofColor = "#FFFFFF";
        this.BuildingId = Guid.NewGuid();
    }
}
