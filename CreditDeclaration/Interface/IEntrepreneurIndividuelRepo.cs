using CreditDeclaration.Modals;
using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IEntrepreneurIndividuelRepo
    {
        Task<IEnumerable<EntrepreneurIndividuel>> GetAllEntrepreneurs();
        Task CreateEntrepreneur(EntrepreneurIndividuel entrepreneur);
        Task<EntrepreneurIndividuel> GetEntrepreneur(int id);
        Task UpdateEntrepreneur(EntrepreneurIndividuel entrepreneur);
        Task DeleteEntrepreneur(int id);
    }
}
