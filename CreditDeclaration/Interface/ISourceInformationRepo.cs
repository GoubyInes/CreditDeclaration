using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface ISourceInformationRepo
    {
        Task<IEnumerable<SourceInformationCredit>> GetAllSources();
        Task CreateSource(SourceInformationCredit Source);
        Task<SourceInformationCredit> GetSource(string code);
        Task UpdateSource(SourceInformationCredit Source);
        Task DeleteSource(string code);
    }
}
