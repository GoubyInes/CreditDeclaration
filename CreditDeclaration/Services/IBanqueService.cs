using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IBanqueService
    {
        Task<IEnumerable<Banque>> GetAllBanksAsync();
        Task CreateBankAsync(Banque Bank);
        Task<Banque> GetBankAsync(string code);
        Task UpdateBankAsync(string code, Banque Bank);
        Task DeleteBankAsync(string code);
    }
}
