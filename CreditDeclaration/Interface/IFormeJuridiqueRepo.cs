using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IFormeJuridiqueRepo
    {
        Task<IEnumerable<FormeJuridique>> GetAllForms();
        Task CreateForm(FormeJuridique form);
        Task<FormeJuridique> GetForm(string code);
        Task UpdateForm(FormeJuridique form);
        Task DeleteForm(string code);
    }
}
