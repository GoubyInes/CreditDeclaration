using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IEntitePubliqueRepo
    {
        Task<IEnumerable<EntitePublique>> GetAllEntities();
        Task CreateEntity(EntitePublique entity);
        Task<EntitePublique> GetEntity(string code);
        Task UpdateEntity(EntitePublique entity);
        Task DeleteEntity(string code);
    }
}
