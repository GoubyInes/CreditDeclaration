using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface ITypePersonneRepo
    {
        Task<IEnumerable<TypePersonne>> GetAllPersons();
        Task CreatePerson(TypePersonne person);
        Task<TypePersonne> GetPerson(string code);
        Task UpdatePerson(TypePersonne person);
        Task DeletePerson(string code);
    }
}
