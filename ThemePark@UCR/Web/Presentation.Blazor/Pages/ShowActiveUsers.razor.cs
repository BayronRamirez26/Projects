using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ShowActiveUsers
    {
        // HTML attributes
        BSModal? modalConfirmation;
        BSModal? modalFeedback;
        Persons _person;

        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private bool IsAuthenticatedResult;

        private string _message = "";
        public string colorStatus = "";
        public string modalContent = "";
        public string modalTitle = "";
        public static string acceptMessage = "Aceptar";
        public static string cancelMenssage = "Cancelar";
        public bool success = false;
        private bool _validateStatus;

        private async void ShowModalOnSubmit(Persons persons)
        {
            _person = persons;
            modalTitle = "Confimación de borrar el Usuario";
            modalContent = "<p>¿Está seguro que quiere borrar el Usuario " + _person.User.UserNickName.Value + "?</p>";
            colorStatus = "#B14212;";
            success = true;

            // Show the modal
            await modalConfirmation.ShowAsync();
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
        }

        private IEnumerable<Persons>? personData;
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            IsAuthenticatedResult = authState.User.Identity?.IsAuthenticated ?? false;
            if (IsAuthenticatedResult)
            {
                //return person not user
                personData = await PersonService.GetPersonAsync();
            }
            if (CurrentNavigationUser?.CurrentUser != null)
            {
                Console.WriteLine("JOYA");
                return;
            }
            else
            {
                Console.WriteLine("TRISTE");
            }
        }

        private void NavigateToUserRoles(Persons person)
        {
            UserState.SelectedUser = person.User;
            NavigationManager.NavigateTo("/ShowUserRoles");
        }

        private async void DeletePersons()
        {
            //Delete user service here
            var response = await PersonService.DeletePersonAsync(_person.PersonId);

            if (response)
            {
                // Building was successfully deleted
                personData = await PersonService.GetPersonAsync();
                showSuccessDeleteAlert = true;
                colorStatus = "#95B60A";
                modalContent = "Persona eliminada";
                modalTitle = "Persona eliminada exitosamente!";
            }
            else
            {
                // Building was not deleted
                Console.WriteLine("Person was not deleted");
                showFailDeleteAlert = true;
                colorStatus = "#B14212";
                modalContent = "La Persona no fue eliminada";
                modalTitle = "Persona no pudo ser eliminado!";
            }
            StateHasChanged(); // Notify the component that the state has changed
            modalConfirmation.HideAsync();
            modalFeedback.ShowAsync();
        }

        private bool FilterFunc1(Persons element) => FilterFunc(element, searchString1);

        private bool FilterFunc(Persons element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.User.UserNickName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }


    }
}