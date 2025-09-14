using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IFonctionDirigeantRepo
    {
        Task<IEnumerable<FonctionDirigeant>> GetAllFunctions();
        Task CreateFunction(FonctionDirigeant function);
        Task<FonctionDirigeant> GetFunction(string code);
        Task UpdateFunction(FonctionDirigeant function);
        Task DeleteFunction(string code);
    }
}
