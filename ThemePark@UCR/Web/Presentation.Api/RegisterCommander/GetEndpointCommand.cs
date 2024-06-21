namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.RegisterCommander;

/// <summary>
/// Class that represents the commander of the endpoints.
/// Is used to manage the endpoints.
/// The Command pattern was used to implement this class.
/// </summary>
public class GetEndpointCommand : IEndpointCommander
{
    /// <summary>
    /// Method that registers the endpoints.
    /// </summary>
    public void RegisterEndpoints(IEndpointRouteBuilder routeBuilder, 
        string route, string name, Delegate handler)
    {
        routeBuilder
            .MapGet(route, handler)
            .WithName(name)
            .WithOpenApi();
    }
}
