using BlazorStrap;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class CreateBuilding
{
    private void OnReset(IBSForm bSForm)
    {
        bSForm.Reset();
    }

    public void validateForm()
    {
        if (expectedValidateData == validateData)
        {
            Console.WriteLine("Validated Data: ", validateData);
            IsDisabled = false;
            StateHasChanged();
        }
        else
        {
            Console.WriteLine("Validated Data: ", validateData);
            validateData++;
            IsDisabled = true;
            StateHasChanged();
        }
    }
}