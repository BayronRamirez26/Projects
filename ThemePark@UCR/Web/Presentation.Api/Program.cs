using Newtonsoft.Json;
using UCR.ECCI.PI.ThemePark_UCR.Application;
using UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpace;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpaceTemplate;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Interaction;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureLayerServices(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT token into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Base role authorization services needed

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        // i should not burn this key for security reasons
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here_must_be_this_large"))
    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Create", policy =>
        policy.RequireClaim("permission", "Create"));
    options.AddPolicy("Read", policy =>
        policy.RequireClaim("permission", "Read"));
    options.AddPolicy("Update", policy =>
        policy.RequireClaim("permission", "Update"));
    options.AddPolicy("Delete", policy =>
        policy.RequireClaim("permission", "Delete"));
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();


// AUTHOTIZATION POLICIES:



// AUTHORIZATION SERVICES:
app.MapGet("/authorization-test", (ClaimsPrincipal user) =>
{
    return $"Hello {user.Identity.Name}!";
})
    .RequireAuthorization("Read")
    .WithOpenApi();




// REGISTER ENDPOINTS RELATED TO LEARNING SPACE

// register learning space template endpoints
app.RegisterLearningSpaceTemplateEndpoints();
// register learning space endpoints
app.RegisterLearningSpaceEndpoints();
// register learning space access point endpoints

app.MapDelete("/delete-template_has_component", async (ITemplateService templateService, Guid id) =>
{
    GuidWrapper input = GuidWrapper.Create(id);
    return await templateService.DeleteComponentAsync(input);
})
.WithName("DeleteTemplateHasComponent")
.WithOpenApi();

app.MapGet("/get-components-from-template", async (ITemplateService templateService,
    Guid id) =>
{
    GuidWrapper input = GuidWrapper.Create(id);
    return await templateService.GetComponentsFromTemplateAsync(input);
})
    .WithName("get-components-from-template")
    .WithOpenApi();

app.MapGet("/get-template-from-id", async (ITemplateService templateService,
    Guid id) =>
{
    return await templateService.GetTemplateFromIdAsync(id);
})
    .WithName("get-template-from-id")
    .WithOpenApi();

app.MapGet("/get-template_has_components", async (ITemplateService templateService) =>
    {
        return await templateService.GetTemplate_Has_ComponentsAsync();
    })
    .WithName("get_template_has_components")
    .WithOpenApi();

// register Template has components endpoints
app.MapPost("/create-template-has-components", async (ITemplateService templateService,
       Template_Has_Components template_Has_Components) =>
{
    return await templateService.AddComponentToTemplateAsync(template_Has_Components);
})
    .WithName("CreateTemplateHasComponents")
    .WithOpenApi();

app.MapPost("/create-whiteboard-from-template", async (ITemplateService templateService,
    Guid templateId, Guid learningSpaceId) =>
{
    return await templateService.CreateWhiteboardsFromTemplateAsync(templateId, learningSpaceId);
})
    .WithName("createWhiteboardFromTemplate")
    .WithOpenApi();

app.MapPost("/create-interactiveScreen-from-template", async (ITemplateService templateService,
    Guid templateId, Guid learningSpaceId) =>
{
    return await templateService.CreateInteractiveScreensFromTemplateAsync(templateId, learningSpaceId);

})
    .WithName("createInteractiveScreenFromTemplate")
    .WithOpenApi();

app.MapPost("/create-projector-from-template", async (ITemplateService templateService,
    Guid templateId, Guid learningSpaceId) =>
{
    return await templateService.CreateProjectorsFromTemplateAsync(templateId, learningSpaceId);
})
    .WithName("createProjectorFromTemplate")
    .WithOpenApi();

app.MapPost("/site-properties", async (ISiteService siteServices,
    string universityName, string campusName, string siteName) =>
{
    var site = await siteServices.GetSitePropertiesAsync(
        LongName.Create(universityName),
        LongName.Create(campusName),
        MediumName.Create(siteName));
    return site;
})
.WithName("GetSiteProperties")
.WithOpenApi();

app.MapPost("/get-campusofuniversity", async (ILearningSpaceCascadeService getCampusFromUniversity
   , string input) =>
{
    return await getCampusFromUniversity.GetCampusFromUniversity(input);
})
.WithName("GetCampusFromUniversity")
.WithOpenApi();

app.MapPost("/get-siteofcampus", async (ILearningSpaceCascadeService getSiteFromCampus
   , string input) =>
{
    return await getSiteFromCampus.GetSitesFromCampus(input);
})
.WithName("GetSiteFromCampus")
.WithOpenApi();

app.MapPost("/get-buildingofsite", async (ILearningSpaceCascadeService getBuildingFromSite
   , string input) =>
{
    return await getBuildingFromSite.GetBuildingsFromSite(input);
})
.WithName("GetBuildingFromSite")
.WithOpenApi();

app.MapGet("/get-building", async (ILearningSpaceCascadeService getBuildingService
    , string siteName, string campusName) =>
{

    return await getBuildingService.GetBuilding(siteName, campusName);
})
.WithName("GetBuilding")
.WithOpenApi();

app.MapPost("/get-levelofbuilding", async (ILearningSpaceCascadeService getLevelFromBuilding
   , Building input) =>
{
    return await getLevelFromBuilding.GetLevelFromBuilding(input);
})
.WithName("GetLevelFromBuilding")
.WithOpenApi();

app.MapGet("/list-learningspacetypes", async (ILsTypeServices lsTypeService) =>
{
    return await lsTypeService.GetLSTypesAsync();
})
    .WithName("GetLearningSpaceTypes")
    .WithOpenApi();

app.MapPost("/modify-learningspace-type", async (ILsTypeServices lsTypeService,
    LSType Type) =>
{
    return await lsTypeService.PostUpdateLSTypeAsync(Type);
})
    .WithName("PostModifyLearningSpaceType")
    .WithOpenApi();

// create learningspace type endpoint
app.MapPost("/create-learningspace-type", async (ILsTypeServices lsTypeService,
    LSType Type) =>
{
    return await lsTypeService.PostCreateLSTypeAsync(Type);
})
.WithName("PostCreateLearningSpaceType")
.WithOpenApi();

// delete learningspace type endpoint
app.MapGet("/list-accessPoints", async (IAccessPointService accessPointService) =>
{
    return await accessPointService.GetAccessPointAsync();
})
.WithName("GetAccessPoints")
.WithOpenApi();

// delete learningspace type endpoint
app.MapGet("/list-accessPoints-from-level", async (IAccessPointService accessPointService, 
    Guid guid) =>
{
    GuidWrapper guidWrapped = GuidWrapper.Create(guid);
    return await accessPointService.GetAccessPointsFromLevelAsync(guidWrapped);
})
.WithName("GetAccessPointsByLevel")
.WithOpenApi();

// create accessPoint endpoint
app.MapPost("/create-accessPoint", async (IAccessPointService accessPointService
    , AccessPoint access) =>
{

    return await accessPointService.CreateAccessPointAsync(access);

})
.WithName("CreateAccessPoint")
.WithOpenApi();

// delete accessPoint endpoint
app.MapPost("/modify-accessPoint", async (IAccessPointService accessPointService
    , AccessPoint accessPoint) =>
{
    return await accessPointService.ModifyAccessPointAsync(accessPoint);
})
.WithName("ModifyAccessPoint")
.WithOpenApi();

// delete accessPoint endpoint
app.MapPost("/get-learning-space-by-id", async (ILearningSpaceService getLearningSpaceId
    , Guid inputId) =>
{
    var input = GuidWrapper.Create(inputId);
    return await getLearningSpaceId.GetLearningSpaceFromIdAsync(input);
})
.WithName("GetLearningSpaceById")
.WithOpenApi();

// delete accessPoint endpoint
app.MapPost("/get-learning-space-type-by-id", async (ILearningSpaceService getLearningSpaceTypeId
    , Guid inputId) =>
{
    var input = GuidWrapper.Create(inputId);
    return await getLearningSpaceTypeId.GetLSTypeFromIdAsync(input);
})
.WithName("GetLearningSpaceTypeById")
.WithOpenApi();


// delete accessPoint endpoint
app.MapPost("/get-learning-space-type-by-lstypeid", async (ILearningSpaceService getLearningSpaceTypeId
    , Guid inputId) =>
{
    var input = GuidWrapper.Create(inputId);
    return await getLearningSpaceTypeId.GetLearningSpacesByLSTypeIdAsync(input);
})
.WithName("GetLearningSpacesByLSTypeId")
.WithOpenApi();


app.MapPost("/get-projectors-of-learning-space", async (ILearningSpaceService getProjectorsOfLearningSpace
       , Guid inputId) =>
{
    var input = GuidWrapper.Create(inputId);
    return await getProjectorsOfLearningSpace.GetProjectorsOfALearningSpacesAsync(input);
})
    .WithName("GetProjectorsOfALearningSpaces")
    .WithOpenApi();

app.MapPost("/get-whiteboard-of-learning-space", async (ILearningSpaceService getWhiteboardOfLearningSpace
       , Guid inputId) =>
{
    var input = GuidWrapper.Create(inputId);
    return await getWhiteboardOfLearningSpace.GetWhiteboardOfALearningSpacesAsync(input);
})
    .WithName("GetWhiteboardsOfALearningSpaces")
    .WithOpenApi();

app.MapPost("/get-interactive-screen-of-learning-space", async (ILearningSpaceService getInteractiveScreensOfLearningSpace
       , Guid inputId) =>
{
    var input = GuidWrapper.Create(inputId);
    return await getInteractiveScreensOfLearningSpace.GetInteractiveScreenOfALearningSpacesAsync(input);
})
    .WithName("GetInteractiveScreensOfALearningSpaces")
    .WithOpenApi();

app.MapPost("/get-access-points-of-learning-space", async (ILearningSpaceService getAccessPointsOfLearningSpace
       , Guid inputId) =>
{
    var input = GuidWrapper.Create(inputId);
    return await getAccessPointsOfLearningSpace.GetAccessPointsOfALearningSpacesAsync(input);
})
    .WithName("GetAccessPointsOfALearningSpacesAsync")
    .WithOpenApi();

app.RegisterInteractionEndpoints();
app.RegisterLearningAreaEndpoints();
app.RegisterLearningComponentsEndpoints();
app.Run();


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}