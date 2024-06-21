using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;

public interface IBOTemplateRepository
{
    public Task<IEnumerable<MediumName>> GetBOTemplatesObjectTypesAsync();

    public Task<IEnumerable<MediumName>> GetBOTemplatesPlanesAsync();
    
    public Task<IEnumerable<BOTemplate>> GetAllBOTemplatesAsync();

    public Task<IEnumerable<BOTemplate>> GetBOTemplatesOfTypeAsync(
        MediumName objectType);

    public Task<IEnumerable<BOTemplate>> GetBOTemplatesOfPlaneAsync(
        MediumName plane);

    public Task<IEnumerable<BOTemplate>> GetBOTemplatesOfTypeAndPlaneAsync(
        MediumName objectType, 
        MediumName plane);
}
