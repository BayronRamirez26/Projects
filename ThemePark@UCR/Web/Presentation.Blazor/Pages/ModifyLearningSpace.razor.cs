using System.ComponentModel.DataAnnotations;
using System.Text;
using BlazorStrap;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using System.Text.Json;
using Newtonsoft.Json;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningSpace.ModifyLS;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ModifyLearningSpace
    {
        private LearningSpaces oldlearningSpace { get; set; }
        private string _message = "";
        private LearningSpace learningSpace { get; set; } = new LearningSpace();
        private bool HideBoton = true;
        private bool ShowError;
        public string ModalContent;
        public string ModalTitle;
        public string ColorStatus;
        public string MessageButton2;
        private bool _validateStatus;
        private IEnumerable<LSType>? lSTypesList;
        private IEnumerable<string> CampusList;
        private IEnumerable<string> SiteList;
        private IEnumerable<string> BuildingList;
        private IEnumerable<Level> LevelList;

        private bool isSubmitDisabled = true;

        private void OnReset(IBSForm bSForm)
        {
            bSForm.Reset();
        }

        private async Task OnSubmit()
        {
            if (true)
            {
                ModalTitle = "Espacio de aprendizaje modificado exitosamente!";
                ModalContent = "¿Desea salir?\n";
                _message = "Submitted to database";
                ColorStatus = "#95B60A;";
                Console.WriteLine("VA A CREAR AL BRO");
                Console.WriteLine(learningSpace.Name);
                Console.WriteLine(learningSpace.sizeX);
                Console.WriteLine(learningSpace.sizeY);
                Console.WriteLine(learningSpace.sizeZ);
                Console.WriteLine(learningSpace.Name);
                Console.WriteLine("LEVEL NUMBER: ");
                Console.WriteLine(learningSpace.levelId);
                Guid levelId;
                if (learningSpace.levelId == null)
                {
                    levelId = Guid.Empty;
                }
                else
                {
                    levelId = new Guid(learningSpace.levelId);
                }
                LearningSpaces _learningSpace = new LearningSpaces(
                    oldlearningSpace.LearningSpaceId,
                    ShortName.Create(learningSpace.Name),
                    DoubleWrapper.Create(learningSpace.sizeX),
                    DoubleWrapper.Create(learningSpace.sizeY),
                    DoubleWrapper.Create(learningSpace.sizeZ),
                    MediumName.Create(learningSpace.Fcolor),
                    MediumName.Create(learningSpace.Ccolor),
                    MediumName.Create(learningSpace.Wcolor),
                    GuidWrapper.Create(levelId),
                    GuidWrapper.Create(new Guid(learningSpace.type.ToString())));

                await modifyService.ModifyLearningSpaceAsync(_learningSpace);

                NavigationManager.NavigateTo("list-learningspaces");
            }
        }

        /// <summary>
        /// GoToLLS function is used to "go" to ListLearningSpace in the webpage
        /// </summary>
        private void GoToLLS()
        {
            NavigationManager.NavigateTo("list-learningspaces");
        }

        protected override async Task OnInitializedAsync()
        {
            lSTypesList = await lsTypeServices.GetLSTypesAsync();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var uri = new Uri(NavigationManager.Uri);
            var learningSpaceJson = uri.Query.Replace("?learningSpace=", "");
            Console.WriteLine(learningSpaceJson);
            Console.WriteLine(uri);
            var decodedLearningSpaceJson = Uri.UnescapeDataString(learningSpaceJson);
            Console.WriteLine(decodedLearningSpaceJson);
            oldlearningSpace = System.Text.Json.JsonSerializer.Deserialize<LearningSpaces>(decodedLearningSpaceJson);
            Console.WriteLine(oldlearningSpace.LearningSpaceName.Value);
            learningSpace.oldLearningSpace = oldlearningSpace;
            learningSpace.Id = oldlearningSpace.LearningSpaceId.Value.ToString();
            learningSpace.Name = oldlearningSpace.LearningSpaceName.Value;
            learningSpace.sizeX = oldlearningSpace.SizeX.Value;
            learningSpace.sizeY = oldlearningSpace.SizeY.Value;
            learningSpace.sizeZ = oldlearningSpace.SizeZ.Value;
            learningSpace.Fcolor = oldlearningSpace.FloorColor.Value;
            learningSpace.Ccolor = oldlearningSpace.CeilingColor.Value;
            learningSpace.Wcolor = oldlearningSpace.WallsColor.Value;
            if (oldlearningSpace.LevelId != null)
            {
                learningSpace.levelId = oldlearningSpace.LevelId.Value.ToString();
            }
            learningSpace.type = new Guid (oldlearningSpace.Type.Value.ToString());
        }

        public class LearningSpace
        {
            public LearningSpaces oldLearningSpace;
            public double sizeX { get; set; }
            public double sizeY { get; set; }
            public double sizeZ { get; set; }
            public string? Name { get; set; }
            public string? Wcolor { get; set; }
            public string? Ccolor { get; set; }
            public string? Fcolor { get; set; }
            public string? Id { get; set; }
            public string? levelId { get; set; }
            public Guid? type { get; set; }
            public string? University { get; set; }
            public string? Campus { get; set; }
            public string? SiteName { get; set; }
            public string? BuildingAcronym { get; set; }
            public string? Floor { get; set; }
        }

        private void SetLevelId(string levelId)
        {
            learningSpace.levelId = levelId;
        }

        private bool _isActive { get; set; }

    }
}
