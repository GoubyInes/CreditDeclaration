using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IEntrepreneurIndividuelService
    {
        Task<IEnumerable<EntrepreneurIndividuel>> GetAllEntrepreneursAsync();
        Task CreateEntrepreneurAsync(EntrepreneurIndividuel entrepreneur);
        Task<EntrepreneurIndividuel> GetEntrepreneurAsync(int id);
        Task UpdateEntrepreneurAsync(EntrepreneurIndividuel entrepreneur);
        Task DeleteEntrepreneurAsync(int id);
    }
}
