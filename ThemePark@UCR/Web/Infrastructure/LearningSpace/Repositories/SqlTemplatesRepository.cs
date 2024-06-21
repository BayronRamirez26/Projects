 using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using System.Transactions;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories
{
    /// <summary>
    /// Creates ApplicationDbContext to perform database operations on tables of learning spaces
    /// </summary>
    internal class SqlTemplatesRepository : ITemplateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlTemplatesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates a template and stores it in the database.
        /// </summary>
        public async Task<bool> CreateTemplateAsync(Templates template)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.Templates.AddAsync(template);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create Template: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        /// <summary>
        /// Returns all templates available in the database.
        /// </summary>
        public async Task<IEnumerable<Templates>> GetTemplatesAsync()
        {
            try
            {
                return await _dbContext.Templates.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not get Templates: {ex.Message}");
                return Enumerable.Empty<Templates>();
            }
        }

        /// <summary>
        /// Updates the information of an existing template.
        /// </summary>
        public async Task<bool> ModifyTemplateAsync(Templates template )
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _dbContext.Templates.Update(template);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Template: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        /// <summary>
        /// Deletes a template from the database.
        /// </summary>
        public async Task<bool> DeleteTemplateAsync(Guid id )
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var template = await _dbContext.Templates.FindAsync(id);
                if (template == null)
                {
                    return false;
                }

                var associatedComponents = await _dbContext.Template_Has_Components
                    .Where(tc => tc.Template == GuidWrapper.Create(id))
                    .ToListAsync();

                if (associatedComponents.Any())
                {
                    _dbContext.Template_Has_Components.RemoveRange(associatedComponents);
                }
                await _dbContext.SaveChangesAsync();
                _dbContext.Templates.Remove(template);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Template: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        /// <summary>
        /// Creates whiteboards from a template in the database.
        /// </summary>
        public async Task<bool> CreateWhiteboardsFromTemplateAsync(Guid templateId, Guid learningSpaceId )
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                GuidWrapper templateIdWrapped = GuidWrapper.Create(templateId);
                var filteredComponents = await _dbContext.Template_Has_Components
                    .Where(wh => wh.Template == templateIdWrapped)
                    .ToListAsync();

                var whiteboards = filteredComponents
                    .Where(wh => wh.Component_type.Value == "Pizarra")
                    .ToList();

                if (whiteboards == null || !whiteboards.Any())
                {
                    Console.WriteLine("No whiteboards found");
                    return false;
                }

                foreach (var templateWhiteboard in whiteboards)
                {
                    var newWhiteboard = new Whiteboard(
                        templateWhiteboard.Component_type,
                        Size.Create(templateWhiteboard.SizeX.Value),
                        Size.Create(templateWhiteboard.SizeY.Value),
                        Coordinate.Create(templateWhiteboard.PositionX.Value),
                        Coordinate.Create(templateWhiteboard.PositionY.Value),
                        Coordinate.Create(templateWhiteboard.PositionZ.Value),
                        Coordinate.Create(templateWhiteboard.RotationX.Value),
                        Coordinate.Create(templateWhiteboard.RotationY.Value),
                        GuidWrapper.Create(learningSpaceId)
                    );

                    _dbContext.Whiteboard.Add(newWhiteboard);
                }

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create WhiteBoards: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> CreateProjectorsFromTemplateAsync(Guid templateId, Guid learningSpaceId)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                GuidWrapper templateIdWrapped = GuidWrapper.Create(templateId);
                var filteredComponents = await _dbContext.Template_Has_Components
                    .Where(wh => wh.Template == templateIdWrapped)
                    .ToListAsync();

                var projectors = filteredComponents
                    .Where(wh => wh.Component_type.Value == "Proyector")
                    .ToList();

                if (projectors == null || !projectors.Any())
                {
                    Console.WriteLine("No projectors found");
                    return false;
                }

                int idIterator = 0;
                foreach (var templateProjector in projectors)
                {
                    var newProjector = new Projector(
                        templateProjector.Component_type,
                        Size.Create(templateProjector.SizeX.Value),
                        Size.Create(templateProjector.SizeY.Value),
                        Coordinate.Create(templateProjector.PositionX.Value),
                        Coordinate.Create(templateProjector.PositionY.Value),
                        Coordinate.Create(templateProjector.PositionZ.Value),
                        Coordinate.Create(templateProjector.RotationX.Value),
                        Coordinate.Create(templateProjector.RotationY.Value),
                        GuidWrapper.Create(learningSpaceId)
                    );

                    _dbContext.Projectors.Add(newProjector);
                    idIterator++;
                }

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create Projectors: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> CreateInteractiveScreensFromTemplateAsync(Guid templateId, Guid learningSpaceId )
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                GuidWrapper templateIdWrapped = GuidWrapper.Create(templateId);
                var filteredComponents = await _dbContext.Template_Has_Components
                    .Where(wh => wh.Template == templateIdWrapped)
                    .ToListAsync();

                var interactiveScreens = filteredComponents
                    .Where(wh => wh.Component_type.Value == "Pantalla Interactiva")
                    .ToList();

                if (interactiveScreens == null || !interactiveScreens.Any())
                {
                    Console.WriteLine("No interactive screens found");
                    return false;
                }

                foreach (var templateInteractiveScreen in interactiveScreens)
                {
                    var newInteractiveScreen = new InteractiveScreen(
                        templateInteractiveScreen.Component_type,
                        Size.Create(templateInteractiveScreen.SizeX.Value),
                        Size.Create(templateInteractiveScreen.SizeY.Value),
                        Coordinate.Create(templateInteractiveScreen.PositionX.Value),
                        Coordinate.Create(templateInteractiveScreen.PositionY.Value),
                        Coordinate.Create(templateInteractiveScreen.PositionZ.Value),
                        Coordinate.Create(templateInteractiveScreen.RotationX.Value),
                        Coordinate.Create(templateInteractiveScreen.RotationY.Value),
                        GuidWrapper.Create(learningSpaceId)
                    );

                    _dbContext.InteractiveScreens.Add(newInteractiveScreen);
                }

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create InteractiveScreens: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<IEnumerable<Templates>> GetTemplateFromIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Templates
                    .Where(w => w.Id == id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not get Template: {ex.Message}");
                return Enumerable.Empty<Templates>();
            }
        }

        public async Task<bool> AddComponentToTemplateAsync(Template_Has_Components template_Has_Components )
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.Template_Has_Components.AddAsync(template_Has_Components);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not add component to Template: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<IEnumerable<Template_Has_Components>> GetTemplate_Has_ComponentsAsync()
        {
            try
            {
                return await _dbContext.Template_Has_Components.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not get Template components: {ex.Message}");
                return Enumerable.Empty<Template_Has_Components>();
            }
        }

        public async Task<IEnumerable<Template_Has_Components>> GetComponentsFromTemplateAsync(GuidWrapper id)
        {
            try
            {
                return await _dbContext.Template_Has_Components
                    .Where(tc => tc.Template == id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not get Template components: {ex.Message}");
                return Enumerable.Empty<Template_Has_Components>();
            }
        }

        public async Task<bool> DeleteComponentAsync(GuidWrapper id )
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var component = await _dbContext.Template_Has_Components.FindAsync(id);
                if (component == null)
                {
                    return false;
                }

                _dbContext.Template_Has_Components.Remove(component);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not delete component: {ex.Message}");
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
