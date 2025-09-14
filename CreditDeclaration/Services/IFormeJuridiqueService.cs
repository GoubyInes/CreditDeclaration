using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IFormeJuridiqueService
    {
        Task<IEnumerable<FormeJuridique>> GetAllFormsAsync();
        Task CreateFormAsync(FormeJuridique form);
        Task<FormeJuridique> GetFormAsync(string code);
        Task UpdateFormAsync(string code, FormeJuridique form);
        Task DeleteFormAsync(string code);
    }
}
