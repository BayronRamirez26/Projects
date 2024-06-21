using BlazorStrap;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;
namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class CreateLearningSpaceType
    {

        private LearningSpaceType learningSpaceType { get; set; } = new LearningSpaceType();
        public bool IsDisabled = true;

        /// <summary>
        /// GoToLLS function is used to "go" to ListLearningSpaceTypes in the webpage
        /// </summary>
        private void GoToLLST()
        {

            NavigationManager.NavigateTo("list-learningspacetypes");
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

        protected override async Task OnInitializedAsync()
        {
            ValidationService service = new ValidationService();
            bool canAccess = await service.hasPermition(currentNavigationUser, "Create");
            if (!canAccess)
            {
                NavigationManager.NavigateTo("/");
            }
        }

            private void OnReset(IBSForm bSForm)
        {
            bSForm.Reset();
        }

        private async void submit()
        {
            Console.WriteLine("hola");
            Console.WriteLine(Name);
            LSType lstype = new LSType(Guid.NewGuid(), MediumName.Create(Name));

            if (Name != null)
            {
                await lsTypeServices.PostCreateLSTypeAsync(lstype);
                NavigationManager.NavigateTo("list-learningspacetypes");
            }

        }
        private void OnSubmit(EditContext e)
        {
            submit();
        }
    }
}