using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IDureeRepo
    {
        Task<IEnumerable<DureeCredit>> GetAllDurations();
        Task CreateDuration(DureeCredit Duration);
        Task<DureeCredit> GetDuration(string code);
        Task UpdateDuration(DureeCredit Duration);
        Task DeleteDuration(string code);
    }
}
