using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface INiveauResponsabiliteRepo
    {
        Task<IEnumerable<NiveauResponsabilite>> GetAllLevels();
        Task CreateLevel(NiveauResponsabilite level);
        Task<NiveauResponsabilite> GetLevel(string code);
        Task UpdateLevel(NiveauResponsabilite level);
        Task DeleteLevel(string code);
    }
}
