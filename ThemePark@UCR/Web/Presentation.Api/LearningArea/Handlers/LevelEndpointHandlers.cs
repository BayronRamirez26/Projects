using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Handlers;

public static class LevelEndpointHandlers
{

    /// <summary>
    /// Endpoint to get the levels from a building.
    /// </summary>
    /// <param name="levelService"></param>
    /// <param name="UniversityName"></param>
    /// <param name="CampusName"></param>
    /// <param name="SiteName"></param>
    /// <param name="BuildingAcronym"></param>
    /// <returns></returns>
    public static async Task<IEnumerable<Level>?> GetLevelsFromBuildingAsync(
        [FromServices] ILevelService levelService,
        string UniversityName,
        string CampusName,
        string SiteName,
        string BuildingAcronym)
    {
        try
        {
            var uName = LongName.Create(UniversityName);
            var cName = LongName.Create(CampusName);
            var sName = MediumName.Create(SiteName);
            var Acro = ShortName.Create(BuildingAcronym);

            var levels = await levelService.GetLevelsFromBuildingAsync(uName, cName, sName, Acro);

            return levels;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapGet: {ex.Message}");
            Console.WriteLine($"Error in the mapGet: {ex.StackTrace}");
            //return Results.BadRequest("Levels could not be found: " + ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Endpoint to create a level.
    /// </summary>
    /// <param name="levelService"></param>
    /// <param name="levelId"></param>
    /// <param name="universityName"></param>
    /// <param name="campusName"></param>
    /// <param name="siteName"></param>
    /// <param name="buildingAcronym"></param>
    /// <param name="levelNumber"></param>
    /// <param name="sizeX"></param>
    /// <param name="sizeY"></param>
    /// <param name="sizeZ"></param>
    /// <param name="wallsColor"></param>
    /// <param name="floorColor"></param>
    /// <param name="ceilingColor"></param>
    /// <param name="learningSpacesCount"></param>
    /// <returns></returns>
    public static async Task<bool> CreateLevelAsync(
        [FromServices] ILevelService levelService, 
        Guid levelId,
        string universityName,
        string campusName,
        string siteName,
        string buildingAcronym,
        byte levelNumber,
        double sizeX,
        double sizeY,
        double sizeZ,
        string wallsColor,
        string floorColor,
        string ceilingColor,
        byte learningSpacesCount)
    {
        try
        {
            // Implement mapper to pass dto to entity
            Level level = new Level(
                GuidValueObject.Create(levelId),
                LongName.Create(universityName),
                LongName.Create(campusName),
                MediumName.Create(siteName),
                ShortName.Create(buildingAcronym),
                Counter.Create(levelNumber),
                Size.Create(sizeX),
                Size.Create(sizeY),
                Size.Create(sizeZ),
                Color.Create(wallsColor),
                Color.Create(floorColor),
                Color.Create(ceilingColor),
                Counter.Create(learningSpacesCount)
            );

            return await levelService.CreateLevelAsync(level);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the CreateLevel: {ex.Message}");
            Console.WriteLine($"Error in the CreateLevel: {ex.StackTrace}");
            return false;
        }
    }

    public static async Task<bool> UpdateLevelAsync(
        [FromServices] ILevelService levelService,
        Guid levelId, // We shoud not ask the user for a guid
        string universityName,
        string campusName,
        string siteName,
        string buildingAcronym,
        byte levelNumber,
        double sizeX,
        double sizeY,
        double sizeZ,
        string wallsColor,
        string floorColor,
        string ceilingColor,
        byte learningSpacesCount)
    {
        try
        {
            // Implement mapper to pass dto to entity
            Level level = new Level(
                GuidValueObject.Create(levelId),
                LongName.Create(universityName),
                LongName.Create(campusName),
                MediumName.Create(siteName),
                ShortName.Create(buildingAcronym),
                Counter.Create(levelNumber),
                Size.Create(sizeX),
                Size.Create(sizeY),
                Size.Create(sizeZ),
                Color.Create(wallsColor),
                Color.Create(floorColor),
                Color.Create(ceilingColor),
                Counter.Create(learningSpacesCount)
            );

            return await levelService.UpdateLevelAsync(level);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the UpdateLevel: {ex.Message}");
            Console.WriteLine($"Error in the UpdateLevel: {ex.StackTrace}");
            return false;
        }
    }

    public static async Task<bool> DeleteLevelAsync(
        [FromServices] ILevelService levelService,
        Guid levelId)
    {
        try
        {
            Level level = await levelService.GetLevelByIdAsync(levelId);
            return await levelService.DeleteLevelAsync(level);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the DeleteLevel: {ex.Message}");
            Console.WriteLine($"Error in the DeleteLevel: {ex.StackTrace}");
            return false;
        }
    }

    public static async Task<Level> GetLevelByIdAsync(
        [FromServices] ILevelService levelService,
        Guid levelId)
    {
        try
        {
            return await levelService.GetLevelByIdAsync(levelId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the GetLevelById: {ex.Message}");
            Console.WriteLine($"Error in the GetLevelById: {ex.StackTrace}");
            return null;
        }
    }


}

