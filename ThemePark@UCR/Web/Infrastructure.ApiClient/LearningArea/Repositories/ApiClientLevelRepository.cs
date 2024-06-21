using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningArea.Mappers;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LevelByBuilding.LevelByBuildingRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.DeleteLevel.DeleteLevelRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LevelById.LevelByIdRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningArea.Repositories;

internal class ApiClientLevelRepository : ILevelRepository
{
    private readonly Client.ApiClientKiota _apiClient;

    public ApiClientLevelRepository(Client.ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    } 

    public async Task<IEnumerable<Level>> GetLevelsFromBuildingAsync(
        LongName UniversityName,
        LongName CampusName,
        MediumName SiteName,
        ShortName BuildingAcronym)
    {
        var requestConfiguration = new Action<RequestConfiguration<LevelByBuildingRequestBuilderGetQueryParameters>>(config =>
        {
            config.QueryParameters = new LevelByBuildingRequestBuilderGetQueryParameters
            {
                UniversityName = UniversityName.Value,
                CampusName = CampusName.Value,
                SiteName = SiteName.Value,
                BuildingAcronym = BuildingAcronym.Value
            };
        });

        var getAllLevels = await _apiClient.LevelByBuilding.GetAsync(requestConfiguration);

       var levelEntities = getAllLevels?.Select(LevelDtoMapper.ToEntity)
          ?? throw new NullReferenceException();
        return levelEntities;
    }

    public async Task<bool> CreateLevelAsync(Level level)
    {
        Console.WriteLine("CreateLevelAsync");
        bool result = false;
        try
        {
            var queryParameters = new Client.CreateLevel.CreateLevelRequestBuilder.CreateLevelRequestBuilderPutQueryParameters
            {
                LevelId = level.LevelId.Value,
                UniversityName = level.UniversityName.Value,
                CampusName = level.CampusName.Value,
                SiteName = level.SiteName.Value,
                BuildingAcronym = level.BuildingAcronym.Value,
                LevelNumber = level.LevelNumber.Value,
                LearningSpacesCount = level.LearningSpaceCount.Value,
                SizeX = level.SizeX.Value,
                SizeY = level.SizeY.Value,
                SizeZ = level.SizeZ.Value,
                WallsColor = level.WallsColor.Value,
                FloorColor = level.FloorColor.Value,
                CeilingColor = level.CeilingColor.Value
            };
            try
            {
                Console.WriteLine("Before PutAsync");
                var output = await _apiClient.CreateLevel.PutAsync(requestConfig => requestConfig.QueryParameters = queryParameters);
                Console.WriteLine("After PutAsync");
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with PutAsync {ex}");
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with QueryParameters {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        Console.WriteLine("End of CreateLevelAsync");
        return result;
    }

    public async Task<bool> UpdateLevelAsync(Level level)
    {
        bool result = false;
        try
        {
            var queryParameters = new Client.UpdateLevel.UpdateLevelRequestBuilder.UpdateLevelRequestBuilderPutQueryParameters
            {
                LevelId = level.LevelId.Value,
                UniversityName = level.UniversityName.Value,
                CampusName = level.CampusName.Value,
                SiteName = level.SiteName.Value,
                BuildingAcronym = level.BuildingAcronym.Value,
                LevelNumber = level.LevelNumber.Value,
                LearningSpacesCount = level.LearningSpaceCount.Value,
                SizeX = level.SizeX.Value,
                SizeY = level.SizeY.Value,
                SizeZ = level.SizeZ.Value,
                WallsColor = level.WallsColor.Value,
                FloorColor = level.FloorColor.Value,
                CeilingColor = level.CeilingColor.Value
            };
            try
            {
                Console.WriteLine("Before PutAsync");
                var output = await _apiClient.UpdateLevel.PutAsync(requestConfig => requestConfig.QueryParameters = queryParameters);
                Console.WriteLine("After PutAsync");
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with PutAsync {ex}");
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with QueryParameters {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        Console.WriteLine("End of UpdateLevelAsync");
        return result;
    }

    public async Task<bool> DeleteLevelAsync(Guid id)
    {
        Console.WriteLine($"Deleting level with id: {id.ToString()}");

        var requestConfiguration = new Action<RequestConfiguration<DeleteLevelRequestBuilderDeleteQueryParameters>>(config =>
        {
            config.QueryParameters = new DeleteLevelRequestBuilderDeleteQueryParameters
            {
                LevelId = id
            };
        });

        var deleteLevelResponse = await _apiClient.DeleteLevel.DeleteAsync(requestConfiguration);

        return deleteLevelResponse ?? throw new NullReferenceException();
    }

    

    public async Task<Level> GetLevelByIdAsync(Guid id)
    {
        Console.WriteLine($"Api Client Get Level By Id: {id}");
        var requestConfiguration = new Action<RequestConfiguration<LevelByIdRequestBuilderGetQueryParameters>>(config =>
        {
            config.QueryParameters = new LevelByIdRequestBuilderGetQueryParameters
            {
                LevelId = id
            };
        });

        try {
            var levelDto = await _apiClient.LevelById.GetAsync(requestConfiguration);
            if (levelDto == null)
            {
                throw new NullReferenceException();
            }

            Level level = LevelDtoMapper.ToEntity(levelDto);

            return level;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with GetAsync {ex}");
            Console.WriteLine(ex.Message);

            return null;
        }
    }
}
