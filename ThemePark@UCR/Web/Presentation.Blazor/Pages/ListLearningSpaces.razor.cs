using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using System.Text.Json;
using BlazorStrap.V5;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ListLearningSpaces
    {
        public static string acceptMessage = "Aceptar";
        public static string cancelMenssage = "Cancelar";
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private LearningSpaces selectedItem1 = null;
        private HashSet<LearningSpaces> selectedItems = new HashSet<LearningSpaces>();
        private IEnumerable<LearningSpaces>? Elements = new List<LearningSpaces>();
        int rowNumber = 0;

        LearningSpaces _learningSpace;
        BSModal? modal;
        public string modalContent = "";
        public string modalTitle = "";
        private string _message = "";
        public string colorStatus = "";
        public bool response = false;

        private Dictionary<Guid, string> learningSpaceTypeNames = new Dictionary<Guid, string>();

        private async void ShowModalOnSubmit(LearningSpaces learningspace)
        {
            _learningSpace = learningspace;
            modalTitle = "Confimación de borrar el espacio de aprendizaje";
            modalContent = "<p>¿Está seguro que quiere borrar el espacio de aprendizaje: " + _learningSpace.LearningSpaceName.Value + "?</p>";
            colorStatus = "#B14212;";
            response = true;

            // Show the modal
            await modal.ShowAsync();
        }


        // Alert variables
        private bool showSuccessDeleteAlert = false;
        private bool showFailDeleteAlert = false;
        private bool canModify;
        private bool canDelete;
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
            // StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            ValidationService service = new ValidationService();
            canModify = await service.hasPermition(currentNavigationUser, "Update");
            canDelete = await service.hasPermition(currentNavigationUser, "Delete");
            Elements = await learningSpaceService.GetLearningSpaceAsync();
            if (Elements == null)
            {
                Console.WriteLine("Llega vacio el bichillo ---------------------------------");
            }
            if (Elements != null && Elements.Any())
            {
                await LoadLearningSpaceTypeNames();

            }
            else
            {
                Console.WriteLine("No LSTypes found.");
            }
        }

        private async Task LoadLearningSpaceTypeNames()
        {
            foreach (var element in Elements)
            {
                var learningSpaceType = await learningSpaceService.GetLSTypeFromIdAsync(element.Type);
                if (learningSpaceType != null)
                {
                    learningSpaceTypeNames[element.Type.Value] = learningSpaceType.Name.Value;
                }
                else
                {
                    learningSpaceTypeNames[element.Type.Value] = "Unknow";

                }
            }
        }

        private string GetLearningSpaceTypeName(GuidWrapper id)
        {
            if (learningSpaceTypeNames.TryGetValue(id.Value, out var name))
            {
                return name;
            }
            return "Unknown";
        }

        private bool FilterFunc1(LearningSpaces element) => FilterFunc(element, searchString1);

        private bool FilterFunc(LearningSpaces element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.LearningSpaceName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            // if (element.Type.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //     return true;
            return false;
        }

        private void modifyLS(LearningSpaces learningSpace)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine(rowNumber);
            Console.WriteLine("------------------------");
            var jsonLearningSpace = JsonSerializer.Serialize(learningSpace);
            NavigationManager.NavigateTo($"/modify-learning-space?learningSpace={Uri.EscapeDataString(jsonLearningSpace)}");
        }

        private async void deleteLearningSpace()
        {
            var success = await learningSpaceService.DeleteLearningSpaceAsync(_learningSpace.LearningSpaceId);

            if (success)
            {
                Elements = await learningSpaceService.GetLearningSpaceAsync();
                showSuccessDeleteAlert = true;
            }
            else
            {
                showFailDeleteAlert = true;
            }
            StateHasChanged();
            if (modal != null)
            {
                await modal.HideAsync();
            }
        }

        private void increment()
        {
            rowNumber += 1;
        }
    }
}
