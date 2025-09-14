using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface ITypeCreditService
    {
        Task<IEnumerable<TypeCredit>> GetAllTypesAsync();
        Task CreateTypeAsync(TypeCredit type);
        Task<TypeCredit> GetTypeAsync(string code);
        Task UpdateTypeAsync(string code, TypeCredit type);
        Task DeleteTypeAsync(string code);
    }
}
