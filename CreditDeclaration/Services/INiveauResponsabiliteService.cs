using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface INiveauResponsabiliteService
    {
        Task<IEnumerable<NiveauResponsabilite>> GetAllLevelsAsync();
        Task CreateLevelAsync(NiveauResponsabilite level);
        Task<NiveauResponsabilite> GetLevelAsync(string code);
        Task UpdateLevelAsync(string code, NiveauResponsabilite level);
        Task DeleteLevelAsync(string code);
    }
}
