$apiClientLocations = @("../Web/Infrastructure.ApiClient/Client", "../ThemeParkUCR/Assets/Scripts/Infrastructure/Client")

$apiClientLocations | ForEach-Object {
    & kiota generate -l CSharp -c ApiClientKiota -n UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client -d https://localhost:7168/swagger/v1/swagger.json -o $_ --clean-output
}