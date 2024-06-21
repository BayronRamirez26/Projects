using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.EntityConfigurations;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.EntityConfigurations;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Person.EntityConfigurations;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.EntityConfiguration;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.EntityConfigurations;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Shared.EntityConfigurations;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure;


/// <summary>
/// Interface to use sql and database operations from Database
/// </summary>
public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Site> Site { get; set; }
    /// <summary>
    /// Gets or sets the DbSet representing the learningSpace entity.
    /// </summary>
    public virtual DbSet<LearningSpaces> LearningSpaces { get; set; }

    public virtual DbSet<AccessPoint> AccessPoints { get; set; }

    public virtual DbSet<Building> Building { get; set; }

    public virtual DbSet<Campus> Campus { get; set; }

    public virtual DbSet<Level> Level { get; set; }

    public virtual DbSet<BOTemplate> BOTemplate { get; set; }
    public virtual DbSet<BuildingObject> BuildingObject { get; set; }

    public virtual DbSet<LearningComponent> LearningComponents { get; set; }
    public virtual DbSet<LSType> LSTypes { get; set; }

    public virtual DbSet<Templates> Templates { get; set; }

    // Users and Roles tables
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Whiteboard> Whiteboard { get; set; }

    public virtual DbSet<LearningComponentDto> LearningComponentDtos { get; set; }
    public virtual DbSet<InteractiveScreen> InteractiveScreens { get; set; }
    public virtual DbSet<Projector> Projectors { get; set; }
    public virtual DbSet<AIAssistant> AIAssistants { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Persons> Persons { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Template_Has_Components> Template_Has_Components { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }


    /// <summary>
    /// ApplicationDbContext constructor to initialize the options
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {
    }


    [Obsolete("Only for mocking purposes", true)]
    internal ApplicationDbContext()
    {
    }
    /// <summary>
    /// OnModelCreating method to configure the relationship between entities
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Assembly LearningSpaces Configuration
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration<LearningSpaces>(new LearningSpacesEntityConfiguration());

        modelBuilder.ApplyConfiguration<LSType>(new LearningSpaceTypeEntityConfiguration());
        // Assembly Classroom Configuratio
        modelBuilder.ApplyConfiguration(new CampusEntityConfiguration());
        // Assembly Site Configuration
        modelBuilder.ApplyConfiguration<Site>(new SiteEntityConfiguration());
        // Assembly Site Occupied Spot Configuration

        modelBuilder.ApplyConfiguration<Campus>(new CampusEntityConfiguration());
     
        modelBuilder.ApplyConfiguration<Level>(new LevelEntityConfiguration());

        modelBuilder.ApplyConfiguration<BOTemplate>(new BOTemplateEntityConfiguration());
        modelBuilder.ApplyConfiguration<BuildingObject>(new BuildingObjectEntityConfiguration());

        //Assembly LearningComponentConfiguration

        //Assembly AccessPointConfiguration
        modelBuilder.ApplyConfiguration<AccessPoint>(new AccessPointEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SiteEntityConfiguration());
        // Assembly Building Configuration
        modelBuilder.ApplyConfiguration(new BuildingEntityConfiguration());
        // Assembly Level Configuration
        modelBuilder.ApplyConfiguration(new LevelEntityConfiguration());
        //Assembly LearningSpacesConfiguration
        modelBuilder.ApplyConfiguration(new LearningSpacesEntityConfiguration());
        //Assembly LearningComponentConfiguration
        modelBuilder.Entity<LearningComponent>().UseTpcMappingStrategy();
        modelBuilder.Entity<LearningComponentDto>().HasNoKey().ToView(null);
        modelBuilder.ApplyConfiguration(new WhiteboardEntityConfiguration());
        modelBuilder.ApplyConfiguration(new InteractiveScreenEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectorEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AIAssistantEntityConfiguration());

        modelBuilder.ApplyConfiguration<Templates>(new TemplatesEntityConfiguration());

        modelBuilder.ApplyConfiguration<Template_Has_Components>(new Template_Has_ComponentsEntityConfiguration());

        LearningSpaceRelationConfiguration(modelBuilder);
        //Assembly LearningComponentConfiguration
        //UserRelationConfiguration(modelBuilder);

        // Assembly Person Configuration
        modelBuilder.ApplyConfiguration(new PersonsEntityConfiguration());

        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        // Assembly Role Configuration
        modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        
        modelBuilder.ApplyConfiguration(new PermissionEntityConfiguration());

        modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());

        modelBuilder.ApplyConfiguration(new ProfessorEntityConfiguration());

    }

    /// <summary>
    /// LearningSpaceRelationConfiguration method to configure the relationship between LearningSpace and AccessPoint entities
    /// </summary>
    /// <param name="modelBuilder"></param>
    private static void LearningSpaceRelationConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LearningSpaces>()
            .HasMany(ls => ls.accessPoints)
            .WithOne(ap => ap.learningSpace)
            .HasForeignKey(ap => ap.LearningSpaceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
