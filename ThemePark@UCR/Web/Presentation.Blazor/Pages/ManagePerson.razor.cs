using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class ManagePerson
    {
        private BSModal? modal;
        private BSModal? confirmDeleteModal;
        private BSModal? confirmUpdateModal;
        [Parameter]
        public Guid personId { get; set; }

        private Persons person = new Persons(); // Asegurarse de que el modelo esté inicializado

        private string modalContent = "";
        private string modalTitle = "";
        private string colorStatus = "";
        private string firstName = "";
        private string middleName = "";
        private string firstLastName = "";
        private string secondLastName = "";
        private DateOnly birthDate = DateOnly.FromDateTime(DateTime.Now);
        private string phoneNumber = "";
        private string email = "";

        private IEnumerable<Persons>? personInformation;

        private bool success = false;

        protected override async Task OnInitializedAsync()
        {
            personInformation = await PersonService.GetPersonAsync();
            person = personInformation.FirstOrDefault(p => p.PersonId == personId) ?? new Persons(); // Inicializar si es nulo

            if (person != null)
            {
                firstName = person.FirstName?.Value ?? "";
                middleName = person.MiddleName?.Value ?? "";
                firstLastName = person.FirstLastName?.Value ?? "";
                secondLastName = person.SecondLastName?.Value ?? "";
                birthDate = person.BirthDate?.Value ?? DateOnly.FromDateTime(DateTime.Now);
                phoneNumber = person.PhoneNumber?.Value ?? "";
                email = person.Email?.Value ?? "";
            }
        }

        private bool isEditing = false; // Variable para controlar la edición

        private async Task OnSubmit()
        {
            person.FirstName = UserNameValueObject.Create(firstName);
            person.MiddleName = UserNameValueObject.Create(middleName);
            person.FirstLastName = UserNameValueObject.Create(firstLastName);
            person.SecondLastName = UserNameValueObject.Create(secondLastName);
            person.BirthDate = BirthDateValueObject.Create(birthDate);
            person.PhoneNumber = PhoneValueObject.Create(phoneNumber);
            person.Email = EmailValueObject.Create(email);

            bool result = await PersonService.UpdatePersonAsync(person);

            if (result)
            {
                modalTitle = "Operación exitosa";
                modalContent = "<p>La persona fue guardada exitosamente.</p>";
                colorStatus = "#95B60A;";
                success = true;
            }
            else
            {
                modalTitle = "Error";
                modalContent = "<p>Hubo un error al guardar la persona.</p>";
                colorStatus = "#B14212;";
                success = false;
            }
            await modal.ShowAsync();
        }

        private void ConfirmUpdate()
        {
            confirmUpdateModal.ShowAsync();
        }

        private async Task ExecuteUpdate()
        {
            try
            {
                Console.WriteLine("Executing update...");
                person.FirstName = UserNameValueObject.Create(firstName);
                person.MiddleName = UserNameValueObject.Create(middleName);
                person.FirstLastName = UserNameValueObject.Create(firstLastName);
                person.SecondLastName = UserNameValueObject.Create(secondLastName);
                Console.WriteLine($"BirthDate: {birthDate}");
                person.BirthDate = BirthDateValueObject.Create(birthDate);
                Console.WriteLine($"BirthDate: {birthDate}");
                person.PhoneNumber = PhoneValueObject.Create(phoneNumber);
                person.Email = EmailValueObject.Create(email);

                Console.WriteLine($"Person data before update: {JsonSerializer.Serialize(person)}");

                bool result = await PersonService.UpdatePersonAsync(person);
                // Imprimir el valor de retorno en la consola
                Console.WriteLine($"Update result: {result}");

                Console.WriteLine($"Update result: {result}");

                if (result)
                {
                    modalTitle = "Operación exitosa";
                    modalContent = "<p>La persona fue actualizada exitosamente.</p>";
                    colorStatus = "#95B60A;";
                    success = true;
                }
                else
                {
                    modalTitle = "Error";
                    modalContent = "<p>Hubo un error al actualizar la persona.</p>";
                    colorStatus = "#B14212;";
                    success = false;
                }
                await modal.ShowAsync();
                await confirmUpdateModal.HideAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ExecuteUpdate: {ex.Message}");
            }
        }

        private void Cancel()
        {
            NavigationManager.NavigateTo("list-persons");
        }

        private void ConfirmDelete()
        {
            confirmDeleteModal.ShowAsync();
        }

        private async Task Delete()
        {
            if (await PersonService.DeletePersonAsync(person.PersonId))
            {
                modalTitle = "Operación exitosa";
                modalContent = "<p>La persona fue eliminada exitosamente.</p>";
                colorStatus = "#95B60A;";
                success = true;
            }
            else
            {
                modalTitle = "Error";
                modalContent = "<p>Hubo un error al eliminar la persona.</p>";
                colorStatus = "#B14212;";
                success = false;
            }
            await modal.ShowAsync();
            await confirmDeleteModal.HideAsync();
        }

        private void CloseModal()
        {
            if (success)
            {
                NavigationManager.NavigateTo("list-persons");
            }
            else
            {
                modal.HideAsync();
            }
        }

        private void CloseConfirmDeleteModal()
        {
            confirmDeleteModal.HideAsync();
        }

        private void CloseConfirmUpdateModal()
        {
            confirmUpdateModal.HideAsync();
        }

        private void OnReset()
        {
            firstName = "";
            middleName = "";
            firstLastName = "";
            secondLastName = "";
            birthDate = DateOnly.FromDateTime(DateTime.Now);
            phoneNumber = "";
            email = "";
        }

        private void StartEditing()
        {
            isEditing = true; // Cambia el estado a modo edición
        }

        private void Canceled()
        {
            isEditing = false; // Cancela la edición y vuelve al estado inicial
        }
    }
}