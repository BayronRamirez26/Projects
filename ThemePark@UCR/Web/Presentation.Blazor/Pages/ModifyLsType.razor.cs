using BlazorStrap;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ModifyLsType
    {
        private LearningSpaceType learningSpaceType { get; set; } = new LearningSpaceType();
        public bool IsDisabled = true;
        public LSType newlearningSpaceType;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var uri = new Uri(NavigationManager.Uri);
            var learningSpaceTypeJson = uri.Query.Replace("?learningspacetype=", "");
            var decodedlearningSpaceTypeJson = Uri.UnescapeDataString(learningSpaceTypeJson);

            newlearningSpaceType = System.Text.Json.JsonSerializer.Deserialize<LSType>(decodedlearningSpaceTypeJson);

            // oldAccessPoint = System.Text.Json.JsonSerializer.Deserialize<AccessPoint>(decodedAccessPointJson);
            // SizeX = oldAccessPoint.CoordX;
            // SizeY = oldAccessPoint.CoordY;
            // SizeZ = oldAccessPoint.CoordZ;
            // LsGuid = oldAccessPoint.LearningSpaceId.Value;
        }

        public class LearningSpaceType
        {
            [Required(ErrorMessage = "El nombre debe ser brindado")]
            public bool IsDisabled = true;
            public string name;
            public string Name
            {
                get => name;
                set
                {
                    name = value;
                    IsDisabled = false;
                }
            }
        }
        public string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                IsDisabled = false;
                StateHasChanged();
            }
        }

        /// <summary>
        /// GoToLLS function is used to "go" to ListLearningSpaceTypes in the webpage
        /// </summary>
        private void GoToLLST()
        {

            NavigationManager.NavigateTo("list-learningspacetypes");
        }


        private void OnReset(IBSForm bSForm)
        {
            bSForm.Reset();
        }

        private async void submit()
        {
            Console.WriteLine("hola");
            Console.WriteLine(Name);
            LSType lstype = new LSType(newlearningSpaceType.Id, MediumName.Create(Name));
            Console.WriteLine("ID: ");
            Console.WriteLine(newlearningSpaceType.Id.ToString());
            if (Name != null)
            {
                await lsTypeServices.PostUpdateLSTypeAsync(lstype);
                NavigationManager.NavigateTo("list-learningspacetypes");
            }

        }
        private void OnSubmit(EditContext e)
        {
            submit();
        }
    }
}