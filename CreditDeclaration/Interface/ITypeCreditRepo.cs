using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface ITypeCreditRepo
    {
        Task<IEnumerable<TypeCredit>> GetAllTypes();
        Task CreateType(TypeCredit country);
        Task<TypeCredit> GetType(string code);
        Task UpdateType(TypeCredit country);
        Task DeleteType(string code);
    }
}
