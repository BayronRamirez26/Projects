using Blazored.LocalStorage;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;

public class CurrentNavigationUser
{
    private readonly ILocalStorageService _localStorage;
    private const string UserKey = "currentUser";

    public CurrentNavigationUser(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public User? CurrentUser { get; private set; }

    public event Action? OnChange;

    public async Task SetUser(User? input)
    {
        CurrentUser = input;
        if (input != null)
        {
            await _localStorage.SetItemAsync(UserKey, JsonSerializer.Serialize(input));
        }
        else
        {
            await _localStorage.RemoveItemAsync(UserKey);
        }
        NotifyStateChanged();
    }

    public async Task LoadUserAsync()
    {
        var userJson = await _localStorage.GetItemAsync<string>(UserKey);
        if (!string.IsNullOrEmpty(userJson))
        {
            CurrentUser = JsonSerializer.Deserialize<User>(userJson);
            NotifyStateChanged();
        }
    }

    public async Task LogoutAsync()
    {
        CurrentUser = null;
        await _localStorage.RemoveItemAsync(UserKey);
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}