using System.ComponentModel.DataAnnotations;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningComponent;

public class ModifyLearningComponentInfo
{
    public string? LearningComponentName { get; set; }

    [Range(1, 700, ErrorMessage = "La coordenada X debe ser mayor a 0 y menor a 700"),
    Required(ErrorMessage = "La coordenada X debe ser asignada")]
    public int centerX { get; set; }

    [Range(1, 700, ErrorMessage = "La coordenada Y debe ser mayor a 0 y menor a 700"),
    Required(ErrorMessage = "La coordenada Y debe ser asignada")]
    public int centerY { get; set; }

    [Range(1, 700, ErrorMessage = "La coordenada Z debe ser mayor a 0 y menor a 700"),
   Required(ErrorMessage = "La coordenada Z debe ser asignada")]
    public int centerZ { get; set; }
    // The size has to be greater than 0
    [Required(ErrorMessage = "El largo debe ser asignado"),
    Range(1, 700, ErrorMessage = "El largo debe ser mayor a 0")
    ]
    public int length { get; set; }

    [Required(ErrorMessage = "El ancho debe ser asignado"),
    Range(1, 700, ErrorMessage = "El ancho debe ser mayor a 0")
    ]
    public int width { get; set; }

   
    [Required(ErrorMessage = "Debe asignarse el componente a un area de aprendizaje")]
    public Guid  learningSpaceId { get; set; }

    public int learningComponentID { get; set; }

    public string learningComponentType { get; set; }

    // default constructor
    public ModifyLearningComponentInfo()
    {
        this.learningComponentID = 0;
        this.centerX = 0;
        this.centerY = 0;
        this.centerZ = 0;
        this.length = 0;
        this.width = 0;
        this.learningSpaceId = Guid.Empty;
        this.LearningComponentName = "";
        this.learningComponentType = "";
    }
}
