using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IEtatCivilService
    {
        Task<IEnumerable<EtatCivil>> GetAllStatusAsync();
        Task CreateStatusAsync(EtatCivil Bank);
        Task<EtatCivil> GetStatusAsync(string code);
        Task UpdateStatusAsync(string code, EtatCivil Bank);
        Task DeleteStatusAsync(string code);
    }
}
