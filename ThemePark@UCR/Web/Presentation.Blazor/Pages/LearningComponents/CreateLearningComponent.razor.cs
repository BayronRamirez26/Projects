using BlazorStrap;
using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningComponent;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;
using static MudBlazor.CategoryTypes;
using Size = UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects.Size;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningComponents
{
    public partial class CreateLearningComponent
    {
        public IEnumerable<LearningSpaces> learningSpaces = new List<LearningSpaces>();

        [Inject]
        public IWhiteboardService WhiteboardService { get; set; } = null!;

        [Inject]
        public IInteractiveScreenService InteractiveScreenService { get; set; } = null!;

        [Inject]
        public IAIAssistantService AIAssistantService { get; set; } = null!;

        [Inject]
        public IProjectorService ProjectorService { get; set; } = null!;

        [Inject]
        public ILearningSpaceService LearningSpaceService { get; set; } = null!;

        private BSModal modal { get; set; } = null!;


        private LearningComponentInfo learningComponent = new LearningComponentInfo();
        private string componentType = "";
        private string modalContent = "";
        private string modalTitle = "";
        private string colorStatus = "";
        private string messageButton1 = "";
        private string messageButton2 = "";
        private bool success = false;
        private bool _validateStatus;

        protected override async Task OnInitializedAsync()
        {
            ValidationService service = new ValidationService();
            bool canAccess = await service.hasPermition(currentNavigationUser, "Create");
            if (!canAccess)
            {
                NavigationManager.NavigateTo("/");
            }
            await LoadLearningSpaces();
            StateHasChanged();
        }

        private async Task OnSubmit(EditContext e)
        {
            if (e.Validate())
            {
                _validateStatus = await CreateLearningComponentAsync();
                await ShowModal(_validateStatus);
            }
            else
            {
                ShowErrorModal();
            }
        }

        private async Task<bool> CreateLearningComponentAsync()
        {
            switch (componentType.ToLower())
            {
                case "projector":
                    return await ProjectorService.CreateProjectorsAsync(CreateProjector());
                case "whiteboard":
                    return await WhiteboardService.CreateWhiteboardsAsync(CreateWhiteboard());
                case "interactivescreens":
                    return await InteractiveScreenService.CreateInteractiveScreensAsync(CreateInteractiveScreen());
                case "aiassistant":
                    return await AIAssistantService.CreateAIAssistantsAsync(CreateAIAssistant());
                default:
                    return false;
            }
        }

        private Projector CreateProjector() => new Projector(
            MediumName.Create(learningComponent.LearningComponentName),
            Size.Create(learningComponent.width),
            Size.Create(learningComponent.length),
            Coordinate.Create(learningComponent.centerX),
            Coordinate.Create(learningComponent.centerY),
            Coordinate.Create(learningComponent.centerZ),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(learningComponent.learningSpaceId)
        );

        private Whiteboard CreateWhiteboard() => new Whiteboard(
            MediumName.Create(learningComponent.LearningComponentName),
            Size.Create(learningComponent.width),
            Size.Create(learningComponent.length),
            Coordinate.Create(learningComponent.centerX),
            Coordinate.Create(learningComponent.centerY),
            Coordinate.Create(learningComponent.centerZ),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(learningComponent.learningSpaceId)
        );

        private InteractiveScreen CreateInteractiveScreen() => new InteractiveScreen(
            MediumName.Create(learningComponent.LearningComponentName),
            Size.Create(learningComponent.width),
            Size.Create(learningComponent.length),
            Coordinate.Create(learningComponent.centerX),
            Coordinate.Create(learningComponent.centerY),
            Coordinate.Create(learningComponent.centerZ),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(learningComponent.learningSpaceId)
        );

        private AIAssistant CreateAIAssistant() => new AIAssistant(
            MediumName.Create(learningComponent.LearningComponentName),
            Size.Create(learningComponent.width),
            Size.Create(learningComponent.length),
            Coordinate.Create(learningComponent.centerX),
            Coordinate.Create(learningComponent.centerY),
            Coordinate.Create(learningComponent.centerZ),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(learningComponent.learningSpaceId)
        );

        private async Task ShowModal(bool isSuccess)
        {
            if (isSuccess)
            {
                modalTitle = "Componente de aprendizaje creado exitosamente!";
                modalContent = "¿Desea crear otro?";
                colorStatus = "#95B60A;";
                messageButton1 = "Crear otro componente";
                messageButton2 = "Ir a la lista de componentes";
                success = true;
            }
            else
            {
                modalTitle = "Ha habido un error";
                modalContent = "¿Desea crear otro?\n";
                colorStatus = "#B14212;";
                messageButton1 = "Volver a la creación de componente de aprendizaje";
            }
            if (modal != null)
            {
                await modal.ShowAsync();
            }
        }

        private void ShowErrorModal()
        {
            _validateStatus = false;
            messageButton1 = "Sí";
            messageButton2 = "No";
            modalTitle = "Ha habido un error";
            modalContent = "El componente de aprendizaje no pudo ser creado.\nSurgieron los siguientes errores en su creación:\n";
            colorStatus = "#B14212;";
        }

        private async Task LoadLearningSpaces()
        {
            if (LearningSpaceService != null)
            {
                learningSpaces = await LearningSpaceService.GetLearningSpaceAsync();
            }
            StateHasChanged();
        }

        private void OnReset(IBSForm bSForm)
        {
            bSForm.Reset();
        }
        private void GoToCreateLearningComponent()
        {
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }

        private void GoToListLearningComponent()
        {
            NavigationManager.NavigateTo("list-lcomponent");
        }

        private void GoToHome()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}