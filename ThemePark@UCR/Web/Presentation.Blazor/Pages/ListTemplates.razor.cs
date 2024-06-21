using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using System.Text.Json;
using BlazorStrap.V5;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;


namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ListTemplates
    {
        private bool canModify;
        private bool canDelete;
        public static string acceptMessage = "Aceptar";
        public static string cancelMenssage = "Cancelar";
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private LearningSpaces selectedItem1 = null;
        private HashSet<LearningSpaces> selectedItems = new HashSet<LearningSpaces>();
        private IEnumerable<Templates>? Elements = new List<Templates>();
        int rowNumber = 0;

        Templates _template;
        LearningSpaces _learningSpace;
        BSModal? modal;
        public string modalContent = "";
        public string modalTitle = "";
        private string _message = "";
        public string colorStatus = "";
        public bool response = false;

        private Dictionary<Guid, string> learningSpaceTypeNames = new Dictionary<Guid, string>();

        private async void ShowModalOnSubmit(Templates template)
        {
            _template = template;
            modalTitle = "Confimación para borrar plantilla";
            modalContent = "<p>¿Está seguro que quiere borrar la plantilla: " + _template.TemplateName.Value + "?</p>";
            colorStatus = "#B14212;";
            response = true;

            // // Show the modal
            await modal.ShowAsync();
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
            // StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            ValidationService service = new ValidationService();
            canModify = await service.hasPermition(currentNavigationUser, "Update");
            canDelete = await service.hasPermition(currentNavigationUser, "Delete");
            Elements = await templateService.GetTemplatesAsync();
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
                var learningSpaceType = await learningSpaceService.GetLSTypeFromIdAsync(GuidWrapper.Create(element.Type));
                if (learningSpaceType != null)
                {
                    learningSpaceTypeNames[element.Type] = learningSpaceType.Name.Value;
                }
                else
                {
                    learningSpaceTypeNames[element.Type] = "Unknow";

                }
            }
        }

        private string GetLearningSpaceTypeName(Guid id)
        {
            if (learningSpaceTypeNames.TryGetValue(id, out var name))
            {
                return name;
            }
            return "Unknown";
        }

        private bool FilterFunc1(Templates element) => FilterFunc(element, searchString1);

        private bool FilterFunc(Templates element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.TemplateName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            // if (element.Type.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //     return true;
            return false;
        }

        private void modifyTemplate(Templates template)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine(rowNumber);
            Console.WriteLine("------------------------");
            var jsonTemplate = JsonSerializer.Serialize(template);
            NavigationManager.NavigateTo($"/modify-template?template={Uri.EscapeDataString(jsonTemplate)}");
        }

        private async void deleteTemplate()
        {
            var success = await templateService.DeleteTemplateAsync(_template.Id);

            if (success)
            {
                Elements = await templateService.GetTemplatesAsync();
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