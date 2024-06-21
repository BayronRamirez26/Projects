using BlazorStrap;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using Newtonsoft.Json;
using BlazorStrap.V5;
using Microsoft.AspNetCore.Components.Forms;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ModifyTemplate
    {
        private string _message = "";
        public bool response = false;

        public GuidWrapper? erasedComponent;
        private bool HideButton = true;

        private Templates oldTemplate { get; set; }
        private LearningSpace learningSpace { get; set; } = new LearningSpace();

        private IEnumerable<LSType>? lSTypesList;
        private bool ShowError;

        public List<string> UniversityList = new List<string> { "Universidad de Costa Rica" };
        private IEnumerable<string>? CampusList;
        private IEnumerable<string>? SiteList;
        private IEnumerable<string>? BuildingList;
        private IEnumerable<Level>? LevelList;
        private IEnumerable<Template_Has_Components>? template_components { get; set; }
        public string? ModalContent;
        public string? ModalTitle;
        public string? ColorStatus;
        public string? MessageButton1;
        public string? MessageButton2;
        public int WhiteboardQuantity;
        public int ScreenQuantity;
        public int ProjectorQuantity;
        BSModal? modal;

        private bool IsDisabled = true;

        private bool _validateStatus;
        private void OnReset(IBSForm bSForm)
        {

            bSForm.Reset();
        }

        private async void SelectComponent(GuidWrapper id)
        {
            erasedComponent = id;
            await modal.ShowAsync();
        }
        private async void DeleteComponent()
        {
            await templateService.DeleteComponentAsync(erasedComponent);
            template_components = await templateService.GetComponents_From_TemplateAsync(GuidWrapper.Create(oldTemplate.Id));
            base.StateHasChanged();
            modal.HideAsync();
        }
        private void GoToAddContext()
        {
            var templateJson = JsonConvert.SerializeObject(oldTemplate);
            var encodedTemplateJson = Uri.EscapeDataString(templateJson);
            NavigationManager.NavigateTo($"/addcomponent-to-template?template={encodedTemplateJson}");
        }

        /// <summary>
        /// OnSubmit function is an event handler that is called when a form is submitted.
        /// In this case the form in question in the form used to create a learning space.
        /// </summary>
        /// <param name="e"></param>
        private void OnSubmit(EditContext e)
        {
            // this condition only return true if the form was correctly filled, no obligatory field were left empty and given data is valid
            if (e.Validate())
            {
                Console.WriteLine("Se va a modificar");
                _validateStatus = true;


                if (learningSpace.Ccolor == null)
                {
                    learningSpace.Ccolor = "#ffffff";
                }
                if (learningSpace.Fcolor == null)
                {
                    learningSpace.Fcolor = "#ffffff";
                }
                if (learningSpace.Wcolor == null)
                {
                    learningSpace.Wcolor = "#ffffff";
                }

                Guid levelId;
                if (learningSpace.Level == null)
                {
                    levelId = Guid.Empty;
                }
                else
                {
                    levelId = new Guid(learningSpace.Level.ToString());
                }

                Templates newTemplate =
                new Templates(oldTemplate.Id,
                    MediumName.Create(learningSpace.Id),
                    DoubleWrapper.Create(learningSpace.SizeX),
                    DoubleWrapper.Create(learningSpace.SizeY),
                    DoubleWrapper.Create(learningSpace.SizeZ),
                    MediumName.Create(learningSpace.Fcolor),
                    MediumName.Create(learningSpace.Ccolor),
                    MediumName.Create(learningSpace.Wcolor),
                    new Guid(learningSpace.LSType.ToString()));
                templateService.ModifyTemplateAsync(newTemplate);
                NavigationManager.NavigateTo("list-templates");

                StateHasChanged();
            }
            // In this case the creation of the learningSpace wasn't successful, it could be because of erroneous data or other problem.
            else
            {
                _validateStatus = false;
                MessageButton1 = "Sí";
                MessageButton2 = "No";
                ModalTitle = "Ha habido un error";
                ModalContent = "El espacio de aprendizaje no pudo ser creado.\nSurgieron los siguientes errores en su creación:\n";
                ColorStatus = "#B14212;";
                StateHasChanged();
            }
        }

        /// <summary>
        /// GoToCLS function is used to "go" to CreateLearningSpace in the webpage
        /// </summary>
        private void GoToCLS()
        {
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }

        /// <summary>
        /// GoToLLS function is used to "go" to ListLearningSpace in the webpage
        /// </summary>
        private void GoToLLS()
        {
            //TODO(ANY): Change to real LLS URL
            NavigationManager.NavigateTo("list-templates");
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("ON INITAILIZE ASYNC");
            lSTypesList = await lsTypeServices.GetLSTypesAsync();
            Asign_later = "off";
            HideButton = true;
            StateHasChanged();
            template_components = await templateService.GetComponents_From_TemplateAsync(GuidWrapper.Create(oldTemplate.Id));
            foreach (var component in template_components)
            {
                if (component.Component_type.Value == "Whiteboard")
                {
                    WhiteboardQuantity++;
                }
                else if (component.Component_type.Value == "Projector")
                {
                    ProjectorQuantity++;
                }
                else if (component.Component_type.Value == "InteractiveScreen")
                {
                    ScreenQuantity++;
                }
            }
        }

        /// <summary>
        /// LearningSpace is a local class used to store the necesary data of a learningSpace instance
        /// </summary>
        ///
        public string asign_later;
        public string Asign_later
        {
            get => asign_later;
            set
            {
                HideButton = !HideButton;
                learningSpace.University = "null";
                learningSpace.Campus = "null";
                learningSpace.SiteName = "null";
                learningSpace.Level = null;
                CampusList = Enumerable.Empty<string>();
                SiteList = Enumerable.Empty<string>();
                BuildingList = Enumerable.Empty<string>();
                LevelList = Enumerable.Empty<Level>();
                StateHasChanged();
                asign_later = value;
            }
        }

        public class LearningSpace
        {

            /* asigned teacher is not used in this implementation
            * after discussion with PO decision was taken to delete this feature
            * as a single learning space can have multiple teachers asigned to it
            */
            public Templates oldTemplate { get; set; }
            public bool isAsigned = false;
            public int numberOfValidValues = 0;
            public int expectedValidValues = 5;
            public int Value1 { get; set; }
            public LearningSpaces oldLearningSpace;
            public int Value2 { get; set; }

            public int Value3 { get; set; }

            public double sizeX;
            [Range(0, 100, ErrorMessage = "La profundidad no puede ser mayor a 100.")]
            public double SizeX
            {
                get => sizeX;
                set
                {

                    sizeX = value;
                    if (sizeX <= 100)
                    {
                        validate();
                    }
                }
            }

            public double sizeY;
            [Range(0, 100, ErrorMessage = "La altura no puede ser mayor a 100.")]
            public double SizeY
            {
                get => sizeY;
                set
                {
                    sizeY = value;
                    if (sizeY <= 100)
                    {
                        validate();
                    }
                }
            }

            public double sizeZ;
            [Range(0, 100, ErrorMessage = "La altura no puede ser mayor a 100.")]
            public double SizeZ
            {
                get => sizeZ;
                set
                {
                    sizeZ = value;
                    if (sizeZ <= 100)
                    {
                        validate();
                    }
                }
            }

            // Wall color
            public string? Wcolor { get; set; }

            // Ceiling color
            public string? Ccolor { get; set; }

            // floor color
            public string? Fcolor { get; set; }

            public string id;
            // Learning Space Id (ShortName)
            [Required(ErrorMessage = "El nombre debe ser brindado")]
            public string? Id
            {
                get => id;
                set
                {
                    id = value;
                    if (value != null)
                    {
                        validate();
                    }
                }
            }


            // Learning space type, classroom, auditorium or laboratory
            public Guid lSType;
            [Required(ErrorMessage = "El tipo de espacio de aprendizaje debe ser asignado")]
            public Guid? LSType
            {
                get => lSType;
                set
                {
                    lSType = new Guid(value.ToString());
                    if (value != null)
                    {
                        validate();
                    }
                }
            }

            private string university;
            // University name
            public string? University { get; set; }


            private string campus;
            // Campus name
            public string? Campus
            { get; set; }

            private string siteName;
            // Faculty name
            public string? SiteName { get; set; }

            // Escuela name
            public string? BuildingAcronym { get; set; }

            public Guid? Level { get; set; }

            public void validate()
            {
                numberOfValidValues++;

                if (numberOfValidValues == expectedValidValues)
                {

                    isAsigned = true;
                }
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Console.WriteLine("ON INITAILIZE NOOOOOOOOOOOOO ASYNC");
            var uri = new Uri(NavigationManager.Uri);
            var templateJson = uri.Query.Replace("?template=", "");
            Console.WriteLine(templateJson);
            Console.WriteLine(uri);
            var decodedtemplateJson = Uri.UnescapeDataString(templateJson);
            Console.WriteLine(decodedtemplateJson);
            oldTemplate = System.Text.Json.JsonSerializer.Deserialize<Templates>(decodedtemplateJson);
            Console.WriteLine(oldTemplate.TemplateName);
            learningSpace.oldTemplate = oldTemplate;
            learningSpace.Id = oldTemplate.Id.ToString();
            learningSpace.Id = oldTemplate.TemplateName.Value;
            learningSpace.sizeX = oldTemplate.SizeX.Value;
            learningSpace.sizeY = oldTemplate.SizeY.Value;
            learningSpace.sizeZ = oldTemplate.SizeZ.Value;
            learningSpace.Fcolor = oldTemplate.FloorColor.Value;
            learningSpace.Ccolor = oldTemplate.CeilingColor.Value;
            learningSpace.Wcolor = oldTemplate.WallsColor.Value;

            learningSpace.LSType = oldTemplate.Type;
        }

        public int numberOfValidValues = 0;
        public int expectedValidValues = 4;
        public void validateStatus()
        {

            Console.WriteLine("Despues del primer if");

            if (numberOfValidValues == expectedValidValues)
            {
                if (learningSpace.isAsigned)
                {
                    Console.WriteLine("dentro del if más profundo eeeh");
                    IsDisabled = false;
                    StateHasChanged();
                }
            }
            else
            {
                numberOfValidValues++;
            }
        }



        public int expectedValidateData = 10;
        public int validateData = 0;
        public void validateForm()
        {
            if (expectedValidateData == validateData && learningSpace.isAsigned)
            {

                IsDisabled = false;
                StateHasChanged();
            }
            else
            {

                validateData++;

                IsDisabled = true;
                StateHasChanged();
            }
        }

        private bool _isActive { get; set; }
        /// <summary>
        /// ToggleSlide function is used to now if the left-side slide is currently "active" or visible or not
        /// </summary>
        private void ToggleSlide()
        {
            if (_isActive)
            {
                _isActive = false;
            }
            else
            {
                _isActive = true;
            }

        }
    }
}