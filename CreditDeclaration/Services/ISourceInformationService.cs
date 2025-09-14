using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface ISourceInformationService
    {
        Task<IEnumerable<SourceInformationCredit>> GetAllSourcesAsync();
        Task CreateSourceAsync(SourceInformationCredit Source);
        Task<SourceInformationCredit> GetSourceAsync(string code);
        Task UpdateSourceAsync(string code, SourceInformationCredit Source);
        Task DeleteSourceAsync(string code);
    }
}
