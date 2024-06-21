using BlazorStrap;
using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningComponent;
using Size = UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects.Size;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningComponents
{
    public partial class ModifyLearningComponent : ComponentBase
    {
        public string componentType { get; set; } = "";
        [Parameter] public string componentJson { get; set; } = "";

        public IEnumerable<LearningSpaces> learningSpaces { get; set; } = new List<LearningSpaces>();

        [Inject] public IWhiteboardService WhiteboardService { get; set; } = null!;
        [Inject] public IInteractiveScreenService InteractiveScreenService { get; set; } = null!;
        [Inject] public IAIAssistantService AIAssistantService { get; set; } = null!;
        [Inject] public IProjectorService ProjectorService { get; set; } = null!;
        [Inject] public ILearningSpaceService LearningSpaceService { get; set; } = null!;
        [Inject] public NavigationManager NavigationManagerLC { get; set; } = null!;

        BSModal modal = new BSModal();
        private ModifyLearningComponentInfo learningComponent { get; set; } = new ();

        public string modalContent = "";
        public string modalTitle = "";
        public string colorStatus = "";
        public string messageButton1 = "";
        public string messageButton2 = "";
        public bool Success = false;
        private bool isDisabled = true;
        public HttpResponseMessage? response;
        private bool _validateStatus;

        protected override async Task OnInitializedAsync()
        {
            ValidationService service = new ValidationService();
            bool canAccess = await service.hasPermition(currentNavigationUser, "Create");
            if (!canAccess)
            {
                NavigationManager.NavigateTo("/");
            }
            await InitializeComponentAsync();
        }

        private async Task InitializeComponentAsync()
        {
            string json = Uri.UnescapeDataString(componentJson);
            try
            {
                learningComponent = JsonConvert.DeserializeObject<ModifyLearningComponentInfo>(json);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializando JSON: {ex.Message}");
            }
            if (learningComponent != null)
            {
                componentType = learningComponent.learningComponentType;
            }
            await LoadLearningSpacesAsync();
            StateHasChanged();
        }

        private async Task LoadLearningSpacesAsync()
        {
            if (LearningSpaceService != null)
            {
                learningSpaces = await LearningSpaceService.GetLearningSpaceAsync();
            }
            StateHasChanged();
        }

        private async Task OnSubmit(EditContext e)
        {
            if (e.Validate())
            {
                _validateStatus = await ModifyLearningComponentAsync();
                await ShowResultModalAsync();
            }
            else
            {
                ShowErrorModal("El componente de aprendizaje no pudo ser creado.");
            }
        }

        private async Task<bool> ModifyLearningComponentAsync()
        {
            switch (componentType)
            {
                case "projector":
                    var projector = CreateProjector();
                    return await ProjectorService.ModifyProjectorAsync(projector);
                case "whiteboard":
                    var whiteboard = CreateWhiteboard();
                    return await WhiteboardService.ModifyWhiteboardAsync(whiteboard);
                case "InteractiveScreens":
                    var interactiveScreen = CreateInteractiveScreen();
                    return await InteractiveScreenService.ModifyInteractiveScreenAsync(interactiveScreen);
                case "AIAssistant":
                    var aiAssistant = CreateAIAssistant();
                    return await AIAssistantService.ModifyAIAssistantAsync(aiAssistant);
                default:
                    return false;
            }
        }

        private Projector CreateProjector() => new (
            LComponentID.Create(learningComponent.learningComponentID),
            MediumName.Create(learningComponent.LearningComponentName),
            Size.Create(learningComponent.width),
            Size.Create(learningComponent.length),
            Coordinate.Create(learningComponent.centerX),
            Coordinate.Create(learningComponent.centerY),
            Coordinate.Create(learningComponent.centerZ),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(learningComponent.learningSpaceId));

        private Whiteboard CreateWhiteboard() => new(
            LComponentID.Create(learningComponent.learningComponentID),
            MediumName.Create(learningComponent.LearningComponentName),
            Size.Create(learningComponent.width),
            Size.Create(learningComponent.length),
            Coordinate.Create(learningComponent.centerX),
            Coordinate.Create(learningComponent.centerY),
            Coordinate.Create(learningComponent.centerZ),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(learningComponent.learningSpaceId));

        private InteractiveScreen CreateInteractiveScreen() => new (
            LComponentID.Create(learningComponent.learningComponentID),
            MediumName.Create(learningComponent.LearningComponentName),
            Size.Create(learningComponent.width),
            Size.Create(learningComponent.length),
            Coordinate.Create(learningComponent.centerX),
            Coordinate.Create(learningComponent.centerY),
            Coordinate.Create(learningComponent.centerZ),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(learningComponent.learningSpaceId));

        private AIAssistant CreateAIAssistant() => new (
            LComponentID.Create(learningComponent.learningComponentID),
            MediumName.Create(learningComponent.LearningComponentName),
            Size.Create(learningComponent.width),
            Size.Create(learningComponent.length),
            Coordinate.Create(learningComponent.centerX),
            Coordinate.Create(learningComponent.centerY),
            Coordinate.Create(learningComponent.centerZ),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(learningComponent.learningSpaceId));

        private async Task ShowResultModalAsync()
        {
            if (_validateStatus)
            {
                SetModalProperties("Componente de aprendizaje modificado exitosamente!", "Será redirigido al listado de componentes","#95B60A;", "Continuar", true);
            }
            else
            {
                SetModalProperties("Ha habido un error", "No fue posible modificar el componente deseado", "#B14212;", "Volver a la creación de componente de aprendizaje", "Ir a la lista de componentes", false);
            }
            await modal.ShowAsync();
        }

        private void SetModalProperties(string title, string content, string color, string button1, string button2, bool success)
        {
            modalTitle = title;
            modalContent = content;
            colorStatus = color;
            messageButton1 = button1;
            messageButton2 = button2;
            Success = success;
        }
        private void SetModalProperties(string title, string content, string color, string button1,  bool success)
        {
            modalTitle = title;
            modalContent = content;
            colorStatus = color;
            messageButton1 = button1;
            Success = success;
        }

        private void ShowErrorModal(string errorMessage)
        {
            SetModalProperties("Ha habido un error", errorMessage, "#B14212;", "Sí", "No", false);
            modal.ShowAsync();
        }
        private void OnReset(IBSForm bSForm) => bSForm.Reset();

        private void GoToListLearningComponent() => NavigationManagerLC.NavigateTo("list-lcomponent");

        private void GoToHome() => NavigationManager.NavigateTo("/");
    }
}





