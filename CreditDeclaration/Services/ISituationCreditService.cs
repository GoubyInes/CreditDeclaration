using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface ISituationCreditService
    {
        Task<IEnumerable<SituationCredit>> GetAllSituationsAsync();
        Task CreateSituationAsync(SituationCredit situation);
        Task<SituationCredit> GetSituationAsync(string code);
        Task UpdateSituationAsync(string code, SituationCredit situation);
        Task DeleteSituationAsync(string code);
    }
}
