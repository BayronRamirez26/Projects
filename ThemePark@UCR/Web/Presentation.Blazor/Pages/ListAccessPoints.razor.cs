using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ListAccessPoints
    {
        private bool canModify;
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private LearningSpaces selectedItem1 = null;
        private HashSet<LearningSpaces> selectedItems = new HashSet<LearningSpaces>();
        private IEnumerable<AccessPoint>? Elements = new List<AccessPoint>();
        private Dictionary<Guid, string> learningSpaceNames = new Dictionary<Guid, string>();
        private List<Level> levels = new List<Level>();
        int rowNumber = 0;
        int iteratorUni = 0;
        int iteratorCampus = 0;
        int iteratorSite = 0;
        int iteratorBuilding = 0;
        int iteratorLevel = 0;
        private string getUniversityName()
        {
            return levels[iteratorUni++].UniversityName.Value;
        }

        private string getCampusName()
        {
            return levels[iteratorCampus++].CampusName.Value;
        }

        private string getSiteName()
        {
            return levels[iteratorSite++].SiteName.Value;
        }

        private string getBuildingName()
        {
            return levels[iteratorBuilding++].BuildingAcronym.Value;
        }

        private string getLevelNumber()
        {
            return levels[iteratorLevel++].LevelNumber.Value.ToString();
        }
        private bool FilterFunc1(AccessPoint element) => FilterFunc(element, searchString1);

        private bool FilterFunc(AccessPoint element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            // if (element.UniversityName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //     return true;
            // if (element.CampusName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //     return true;
            return false;
        }

        protected override async Task OnInitializedAsync()
        {
            ValidationService service = new ValidationService();
            canModify = await service.hasPermition(currentNavigationUser, "Update");
            Elements = await accessPointService.GetAccessPointAsync();
            if (Elements != null && Elements.Any())
            {
                await LoadLearningSpaceNames();
                foreach (var levelI in Elements)
                {
                    Console.WriteLine("SE VA A CARGAR UN LEVEL");
                    Level Ilevel = await levelService.GetLevelByIdAsync(levelI.LevelId.Value);
                    Console.WriteLine(Ilevel.CampusName.Value);
                    Console.WriteLine("SE VA A CARGAR UN LEVEL");
                    levels.Add(Ilevel);
                }
            }
            else
            {
                Console.WriteLine("No AccessPoints found.");
            }
        }

        private async Task LoadLearningSpaceNames()
        {
            foreach (var element in Elements)
            {
                var learningSpace = await learningSpaceService.GetLearningSpaceFromIdAsync(element.LearningSpaceId);
                if (learningSpace != null)
                {
                    learningSpaceNames[element.LearningSpaceId.Value] = learningSpace.LearningSpaceName.Value;
                }
                else
                {
                    learningSpaceNames[element.LearningSpaceId.Value] = "Unknow";

                }
            }
        }

        private string waitForName(GuidWrapper id)
        {
            Task<string> name = GetLevelName(id);
            Console.WriteLine("SE LLAMA NAME");
            Console.WriteLine(id.Value);
            Console.WriteLine("ID");
            Console.WriteLine(name.Result);
            Console.WriteLine("RESULT");
            string a = name.Result;
            Console.WriteLine(a);
            return name.Result;
        }

        private string GetLearningSpaceName(GuidWrapper id)
        {
            if (learningSpaceNames.TryGetValue(id.Value, out var name))
            {
                return name;
            }
            return "Unknown";
        }

        private async Task<string> GetLevelName(GuidWrapper id)
        {
            Console.WriteLine("WASAAAA");
            Level level =
            await levelService.GetLevelByIdAsync(id.Value);
            Console.WriteLine("Get LEVEL SE LLAMA");

            return level.LevelNumber.Value.ToString();
        }

        private void ModifyAccessPoint(AccessPoint accessPoint)
        {
            var jsonAccessPoint = JsonSerializer.Serialize(accessPoint);
            NavigationManager.NavigateTo($"/modify-accesspoint?accesspoint={Uri.EscapeDataString(jsonAccessPoint)}");
        }
    }
}
