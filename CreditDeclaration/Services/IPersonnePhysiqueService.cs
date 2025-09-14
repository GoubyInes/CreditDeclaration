using CreditDeclaration.Modals;
using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IPersonnePhysiqueService
    {
        Task<IEnumerable<PersonnePhysique>> GetAllPersonPhysicsAsync();
        Task CreatePersonPhysicAsync(PersonnePhysique PersonPhysic);
        Task<PersonnePhysique> GetPersonPhysicAsync(int id);
        Task UpdatePersonPhysicAsync(int id, PersonnePhysique PersonPhysic);
        Task DeletePersonPhysicAsync(int id);
    }
}
