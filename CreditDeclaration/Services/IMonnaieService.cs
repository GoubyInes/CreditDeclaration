using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IMonnaieService
    {
        Task<IEnumerable<Monnaie>> GetAllChangesAsync();
        Task CreateChangeAsync(Monnaie change);
        Task<Monnaie> GetChangeAsync(string code);
        Task UpdateChangeAsync(string code,Monnaie change);
        Task DeleteChangeAsync(string code);
    }
}
