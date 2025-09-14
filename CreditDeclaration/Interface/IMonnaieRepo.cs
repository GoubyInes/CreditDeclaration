using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IMonnaieRepo
    {
        Task<IEnumerable<Monnaie>> GetAllChanges();
        Task CreateChange(Monnaie change);
        Task<Monnaie> GetChange(string code);
        Task UpdateChange(Monnaie change);
        Task DeleteChange(string code);
    }
}
