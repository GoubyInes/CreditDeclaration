using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IBanqueRepo
    {
        Task<IEnumerable<Banque>> GetAllBanks();
        Task CreateBank(Banque Bank);
        Task<Banque> GetBank(string code);
        Task UpdateBank(Banque Bank);
        Task DeleteBank(string code);
    }
}
