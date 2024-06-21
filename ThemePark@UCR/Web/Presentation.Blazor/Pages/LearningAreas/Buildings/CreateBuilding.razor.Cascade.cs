namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class CreateBuilding
{
    // Variables for dropdown lists
    // Initialize universityList with 'Universidad de Costa Rica'
    public List<string> universityList = new List<string> { "Universidad de Costa Rica" };
    public IEnumerable<string> campusList { get; set; }
    public IEnumerable<string> siteList { get; set; }

    // Method to get the list of campuses based on the selected university
    public async Task GetCampuses(string university)
    {
        campusList = await cascadeService.GetCampusFromUniversity(university);
        // Empty list of sites
        siteList = Enumerable.Empty<string>();
    }

    // Method to get the list of sites based on the selected campus
    private async Task GetSites(string campus)
    {
        // Get the list of sites
        siteList = await cascadeService.GetSitesFromCampus(campus);
    }
}
