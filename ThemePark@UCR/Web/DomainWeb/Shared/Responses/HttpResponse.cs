namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.Responses;

/// <summary>
/// Endpoint responses for Http requests
/// </summary>
/// <param name="Success"></param>
/// <param name="HttpStatusCode"></param>
/// <param name="Message"></param>
public record HttpResponse(bool Success, int? HttpStatusCode, string? Message);
