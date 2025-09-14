using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IFonctionDirigeantService
    {
        Task<IEnumerable<FonctionDirigeant>> GetAllFunctionsAsync();
        Task CreateFunctionAsync(FonctionDirigeant function);
        Task<FonctionDirigeant> GetFunctionAsync(string code);
        Task UpdateFunctionAsync(string code,FonctionDirigeant function);
        Task DeleteFunctionAsync(string code);
    }
}

