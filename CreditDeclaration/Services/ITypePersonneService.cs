using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface ITypePersonneService
    {
        Task<IEnumerable<TypePersonne>> GetAllPersonsAsync();
        Task CreatePersonAsync(TypePersonne person);
        Task<TypePersonne> GetPersonAsync(string code);
        Task UpdatePersonAsync(string code, TypePersonne person);
        Task DeletePersonAsync(string code);
    }
}
