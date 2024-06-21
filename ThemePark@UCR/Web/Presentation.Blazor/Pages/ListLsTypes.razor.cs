using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ListLsTypes
    {
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private LearningSpaces selectedItem1 = null;
        private HashSet<LearningSpaces> selectedItems = new HashSet<LearningSpaces>();
        private IEnumerable<LSType>? Elements = new List<LSType>();
        int rowNumber = 0;
        private bool canModify;

        protected override async Task OnInitializedAsync()
        {
            ValidationService service = new ValidationService();
            canModify = await service.hasPermition(currentNavigationUser, "Update");
            Elements = await lsTypeServices.GetLSTypesAsync();
        }

        private bool FilterFunc1(LSType element) => FilterFunc(element, searchString1);

        private void ViewTypes(Guid id)
        {
            NavigationManager.NavigateTo($"/list-types/{Uri.EscapeDataString(id.ToString())}");
        }

        private bool FilterFunc(LSType element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            // if (element.UniversityName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //     return true;
            // if (element.CampusName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //     return true;
            return false;
        }

        private void modifyLS(LSType learningSpace)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine(rowNumber);
            Console.WriteLine("------------------------");
            var jsonLearningSpace = JsonSerializer.Serialize(learningSpace);
            NavigationManager.NavigateTo($"/modify-learningspacetype?learningspacetype={Uri.EscapeDataString(jsonLearningSpace)}");
        }

        private void increment()
        {
            rowNumber += 1;
        }
    }
}