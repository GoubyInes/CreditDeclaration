using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface ISituationCreditRepo
    {
        Task<IEnumerable<SituationCredit>> GetAllSituations();
        Task CreateSituation(SituationCredit situation);
        Task<SituationCredit> GetSituation(string code);
        Task UpdateSituation(SituationCredit situation);
        Task DeleteSituation(string code);
    }
}
