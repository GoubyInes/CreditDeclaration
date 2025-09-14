using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IEntitePubliqueService
    {
        Task<IEnumerable<EntitePublique>> GetAllEntitiesAsync();
        Task CreateEntityAsync(EntitePublique entity);
        Task<EntitePublique> GetEntityAsync(string code);
        Task UpdateEntityAsync(string code,EntitePublique entity);
        Task DeleteEntityAsync(string code);
    }
}
