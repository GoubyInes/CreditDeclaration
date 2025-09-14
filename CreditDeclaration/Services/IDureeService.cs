using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IDureeService
    {
        Task<IEnumerable<DureeCredit>> GetAllDurationsAsync();
        Task CreateDurationAsync(DureeCredit Duration);
        Task<DureeCredit> GetDurationAsync(string code);
        Task UpdateDurationAsync(string code, DureeCredit Duration);
        Task DeleteDurationAsync(string code);
    }
}
