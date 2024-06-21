using Microsoft.AspNetCore.Components;
using BlazorStrap;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using Newtonsoft.Json;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;
using BlazorStrap.V5;
using Microsoft.AspNetCore.Components.Forms;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class CreateAccessPoint
    {
        AccessPointR accessPoint { get; set; } = new AccessPointR();
        private IEnumerable<string> CampusList;
        private IEnumerable<string> SiteList;
        private IEnumerable<string> BuildingList;
        private IEnumerable<Level> LevelList;

        private bool _IsDisabled = true;
        private BSModal modal;
        private string ModalTitle;
        private string ModalContent;
        private string ColorStatus;

        private bool _validateStatus;

        private async void submit()
        {
            Console.WriteLine("SUBMIT");
            Console.WriteLine(LsGuid.ToString());

            // Site referencedSite;

            // referencedSite = await siteService.GetSitePropertiesAsync(LongName.Create(University), LongName.Create(Campus), MediumName.Create(SiteName));

            AccessPoint accessPoint = new AccessPoint(GuidWrapper.Create(Guid.NewGuid()), GuidWrapper.Create(LsGuid), GuidWrapper.Create(new Guid(LevelNumber)), SizeX, SizeY, SizeZ,0,0);
            await accessPointService.CreateAccessPointAsync(accessPoint);

            ModalTitle = "Punto de acceso creado exitosamente!";
            ModalContent = "¿Desea crear otro punto de acceso?";
            ColorStatus = "#95B60A;";
            await modal.ShowAsync();
        }

        private void GoToCreateAnother()
        {
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }

        private void GoToList()
        {
            NavigationManager.NavigateTo("/list-accesspoints");
        }

        public class AccessPointR
        {

        }

        private void OnReset(IBSForm bSForm)
        {
            bSForm.Reset();
        }

        private void OnSubmit(EditContext e)
        {
            submit();
        }

        protected override async Task OnInitializedAsync()
        {
            ValidationService service = new ValidationService();
            bool canAccess = await service.hasPermition(currentNavigationUser, "Create");
            if (!canAccess)
            {
                NavigationManager.NavigateTo("/");
            }
            Elements = await learningSpaceService.GetLearningSpaceAsync();
        }

        private bool ShowError;
        private string? university;
        [Required(ErrorMessage = "El nombre de la universidad debe ser asignado")]
        public string? University
        {
            get => university;
            set
            {
                if (value != null)
                {
                    university = value;
                    _ = SearchCampus();
                    SiteList = null;
                    BuildingList = null;
                    LevelList = null;
                    Campus = null;
                    ValidateForm();
                }
            }
        }
        private async Task SearchCampus()
        {
            try
            {
                CampusList = await _cascade.GetCampusFromUniversity(university);
                ValidateForm();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                ShowError = true;
                Console.WriteLine($"Error al obtener los campus: {ex.Message}");
            }
        }
        private string campus;
        [Required(ErrorMessage = "El nombre del campus debe ser asignado")]
        public string? Campus
        {
            get => campus;
            set
            {
                if (value != null)
                {
                    campus = value;
                    _ = SearchSite();
                    BuildingList = null;
                    LevelList = null;
                    ValidateForm();
                }
            }
        }
        private async Task SearchSite()
        {
            try
            {
                SiteList = await _cascade.GetSitesFromCampus(campus);
                ValidateForm();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                ShowError = true;
                Console.WriteLine($"Error al obtener los campus: {ex.Message}");
            }
        }

        private string? siteName;
        [Required(ErrorMessage = "El nombre de la finca debe ser asignado")]
        public string? SiteName
        {
            get => siteName;
            set
            {
                if (value != null)
                {
                    siteName = value;
                    _ = FindBuilding();
                    LevelList = null;
                    ValidateForm();
                }
            }
        }

        private async Task FindBuilding()
        {
            try
            {

                BuildingList = await _cascade.GetBuilding(SiteName, Campus);
                ValidateForm();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                ShowError = true;
                Console.WriteLine($"Error al obtener los campus: {ex.Message}");
            }
        }

        private string? buildingName;
        [Required(ErrorMessage = "El nombre del edificio debe ser asignado")]
        public string? BuildingName
        {
            get => buildingName;
            set
            {
                if (value != null)
                {
                    buildingName = value;
                    _ = FindLevels();
                    ValidateForm();
                }
            }
        }

        private async Task FindLevels()
        {
            try
            {
                LevelList = await levelService.GetLevelsFromBuildingAsync(LongName.Create(University), LongName.Create(Campus), MediumName.Create(SiteName), ShortName.Create(BuildingName));
                ValidateForm();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                ShowError = true;
                Console.WriteLine($"Error al obtener los campus: {ex.Message}");
            }
        }

        private string? levelNumber;
        [Required(ErrorMessage = "El número de nivel debe ser asignado")]
        public string? LevelNumber
        {
            get => levelNumber;
            set
            {
                if (value != null)
                {
                    levelNumber = value;
                    ValidateForm();
                }
            }
        }

        public Guid lsGuid;
        [Required(ErrorMessage = "El ID del espacio de aprendizaje debe ser asignado")]
        public Guid LsGuid
        {
            get => lsGuid;
            set
            {
                if (value != Guid.Empty)
                {
                    lsGuid = value;
                    ValidateForm();
                }
            }
        }

        public double sizeZ;
        [Range(-0.99, 100, ErrorMessage = "El tamaño no puede ser mayor a 100.")]
        public double SizeZ
        {
            get => sizeZ;
            set
            {
                sizeZ = value;
                ValidateForm();
            }
        }

        public double sizeX;
        [Range(-0.99, 100, ErrorMessage = "El tamaño no puede ser mayor a 100.")]
        public double SizeX
        {
            get => sizeX;
            set
            {
                sizeX = value;
                ValidateForm();
            }
        }

        public double sizeY;
        [Range(-0.99, 100, ErrorMessage = "El tamaño no puede ser mayor a 100.")]
        public double SizeY
        {
            get => sizeY;
            set
            {
                sizeY = value;
                ValidateForm();
            }
        }

        private void ValidateForm()
        {
            _IsDisabled = string.IsNullOrWhiteSpace(University) ||
                         string.IsNullOrWhiteSpace(Campus) ||
                         string.IsNullOrWhiteSpace(SiteName) ||
                         string.IsNullOrWhiteSpace(BuildingName) ||
                         string.IsNullOrWhiteSpace(LevelNumber) ||
                         LsGuid == Guid.Empty ||
                         SizeX <= 0 ||
                         SizeY <= 0 ||
                         SizeZ <= 0;

            StateHasChanged();
        }

        private IEnumerable<LearningSpaces>? Elements = [];
    }
}
