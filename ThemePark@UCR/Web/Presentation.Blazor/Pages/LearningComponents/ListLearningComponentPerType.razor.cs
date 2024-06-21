using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningComponent;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningComponents;

    public partial class ListLearningComponentPerType
{
    // Modal
    BSModal? modal { get; set; }= null!;

    dynamic? _item { get; set; } = null!;

    private string _message = "";
    public string modalContent = "";
    public string modalTitle = "";
    public string colorStatus = "";
    public static string acceptMessage = "Aceptar";
    public static string cancelMenssage = "Cancelar";
    public bool success = false;
    private bool _validateStatus;
    private bool canModify;
    private bool canDelete;
    private async Task ShowModalOnSubmit(dynamic item)
    {

        _item = item;

        modalContent = $"<p>¿Está seguro que quiere borrar {_item.LearningComponentName.Value}?</p>";
        modalTitle = $"Confirmación de borrar {_item.LearningComponentName.Value}";

        colorStatus = "#B14212;";
        success = true;
        if (modal != null)
        {
            await modal.ShowAsync();
        }
        // Show the modal
        
    }

    private void GoToList()
    {
        NavigationManager.NavigateTo($"list-component/{ComponentType}");
    }

    // Alert variables
    private bool showSuccessDeleteAlert = false;
    private bool showFailDeleteAlert = false;

    private void CloseMe(bool success)
    {
        Console.WriteLine("Closing alert");
        Console.WriteLine(success);
        if (success)
        {
            showSuccessDeleteAlert = false;
        }
        else
        {
            showFailDeleteAlert = false;
        }
    }

    // search functions
    private string searchString = "";
    private bool SearchCall(dynamic element) => Search(element, searchString);
    private bool Search(dynamic element, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (element.LearningComponentName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }

    // HTML attributes
    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;

    // List of items
    private IEnumerable<dynamic>? _items;

    [Parameter]
    public string ComponentType { get; set; } = "";
    private string ComponentTypeString { get; set; } = "";
    public string componentT { get; set; } = "";

    [Inject]
    public IAIAssistantService AIservice { get; set; } = null!;

    [Inject]
    public IInteractiveScreenService screenService { get; set; } = null!;


    [Inject]
    public IWhiteboardService whiteboardService { get; set; } = null!;


    [Inject]
    public IProjectorService projectorService { get; set; } = null!;


    [Inject]
    public ILearningSpaceService learningSpaceService { get; set; } = null!;


    private IEnumerable<LearningSpaces>? _learningSpaces;


    protected override async Task OnInitializedAsync()
    {
        ValidationService service = new ValidationService();
        canModify = await service.hasPermition(currentNavigationUser, "Update");
        canDelete = await service.hasPermition(currentNavigationUser, "Delete");
        switch (ComponentType)
        {
            case "Asistentes de IA":
                _items = await AIservice.GetAIAssistantsAsync();
                ComponentTypeString = "Asistentes de IA";
                componentT = "AIAssistant";
                break;
            case "Pantallas interactivas":
                _items = await screenService.GetInteractiveScreensAsync();
                ComponentTypeString = "Pantallas interactivas";
                componentT = "InteractiveScreens";
                break;
            case "Pizarras":
                _items = await whiteboardService.GetWhiteboardsAsync();
                ComponentTypeString = "Pizarras";
                componentT = "whiteboard";
                break;
            case "Proyectores":
                _items = await projectorService.GetProjectorsAsync();
                ComponentTypeString = "Proyector";
                componentT = "projector";
                break;
            default:
                NavigationManager.NavigateTo("/");
                break;

        }
        await LoadLearningSpaces();
    }
    private async Task LoadLearningSpaces()
    {
        if (learningSpaceService != null)
        {
            _learningSpaces = await learningSpaceService.GetLearningSpaceAsync();
            StateHasChanged();
        }
    }

    private void ModifyItem(dynamic item)
    {
        ModifyLearningComponentInfo learningComponentInfo = new ModifyLearningComponentInfo();
        learningComponentInfo.learningComponentType = componentT;
        learningComponentInfo.LearningComponentName = item.LearningComponentName.Value;
        learningComponentInfo.learningComponentID = item.LearningComponentAssetId;
        learningComponentInfo.length = (int)item.SizeX.Value;
        learningComponentInfo.width = (int)item.SizeY.Value;
        learningComponentInfo.centerX = (int)item.PositionX.Value;
        learningComponentInfo.centerY = (int)item.PositionY.Value;
        learningComponentInfo.centerZ = (int)item.PositionZ.Value;
        learningComponentInfo.learningSpaceId = item.LearningSpaceId.Value;

        string json = JsonConvert.SerializeObject(learningComponentInfo);
        
        NavigationManager.NavigateTo($"/modify-lcomponent/{Uri.UnescapeDataString(json)}");
    }

    private async Task DeleteItem()
    {
        bool deletionSuccess = false;
        switch (ComponentType)
        {
            case "Asistentes de IA":
                deletionSuccess = await AIservice.DeleteAIAssistantAsync(_item); // Reemplaza con el método adecuado de tu servicio
                break;
            case "Pantallas interactivas":
                deletionSuccess = await screenService.DeleteInteractiveScreenAsync(_item); // Reemplaza con el método adecuado de tu servicio
                break;
            case "Pizarras":
                deletionSuccess = await whiteboardService.DeleteWhiteboardAsync(_item); // Reemplaza con el método adecuado de tu servicio
                break;
            case "Proyectores":
                deletionSuccess = await projectorService.DeleteProjectorAsync(_item); // Reemplaza con el método adecuado de tu servicio
                break;
        }

        if (deletionSuccess)
        {
            // Actualiza la lista de elementos después de la eliminación
            await RefreshItemList();
            showSuccessDeleteAlert = true;
        }
        else
        {
            Console.WriteLine($"{ComponentType} was not deleted");
            showFailDeleteAlert = true;
        }

        // Oculta la modal después de procesar la eliminación
        if (modal != null)
        {
            await modal.HideAsync();
        }

    }

    private async Task RefreshItemList()
    {
        switch (ComponentType)
        {
            case "Asistentes de IA":
                _items = await AIservice.GetAIAssistantsAsync();
                break;
            case "Pantallas interactivas":
                _items = await screenService.GetInteractiveScreensAsync();
                break;
            case "Pizarras":
                _items = await whiteboardService.GetWhiteboardsAsync();
                break;
            case "Proyectores":
                _items = await projectorService.GetProjectorsAsync();
                break;
        }
        StateHasChanged();
    }
    private string GetLearningSpaceName(Guid learningSpaceId)
    {
        if (_learningSpaces == null || !_learningSpaces.Any())
        {
            LoadLearningSpaces();

            if (_learningSpaces == null || !_learningSpaces.Any())
            {
                return "Desconocido";
            }
            StateHasChanged();
        }

        var learningSpace = _learningSpaces.FirstOrDefault(ls => ls.LearningSpaceId.Value == learningSpaceId);
        return learningSpace != null ? learningSpace.LearningSpaceName.Value : "Desconocido";
    }

}

