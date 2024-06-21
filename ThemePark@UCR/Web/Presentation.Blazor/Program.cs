using BlazorStrap;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor;
using MudBlazor.Services;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using Blazored.LocalStorage;
using Microsoft.Extensions.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorStrap();
builder.Services.AddMudServices();
builder.Services.AddSingleton<UserState>();
builder.Services.AddScoped<CurrentNavigationUser>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<LayoutStateService>();
builder.Services.AddSingleton<RolesStateService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add services from the application layer with the extension methods
builder.Services.AddMsalAuthentication(options => //Throws error with kiota when accesing ShowActiveUsers
{
    options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://paaccorgtest.onmicrosoft.com/5f1e55a5-903b-4c39-83e6-429692f32bf2/API.Access");
    options.ProviderOptions.LoginMode = "redirect";
});

// Add services from the application layer with the extension methods
builder.Services.AddApplicationLayerServices();
// Add services from the infrastructure layer with the extension methods
builder.Services.AddInfrastructureApiClientLayerServices(builder.Configuration);

builder.Services.AddAuthorizationCore();



await builder.Build().RunAsync();