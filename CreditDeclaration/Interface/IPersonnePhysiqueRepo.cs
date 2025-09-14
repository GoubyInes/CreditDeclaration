using CreditDeclaration.Modals;
using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IPersonnePhysiqueRepo
    {
        Task<IEnumerable<PersonnePhysique>> GetAllPersonPhysics();
        Task CreatePersonPhysic(PersonnePhysique PersonPhysic);
        Task<PersonnePhysique> GetPersonPhysic(int id);
        Task UpdatePersonPhysic(PersonnePhysique PersonPhysic);
        Task DeletePersonPhysic(int id);
    }
}
