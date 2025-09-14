using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IClasseRetardService
    {
        Task<IEnumerable<ClasseRetard>> GetAllDelaysAsync();
        Task CreateDelayAsync(ClasseRetard Delay);
        Task<ClasseRetard> GetDelayAsync(string code);
        Task UpdateDelayAsync(string code,ClasseRetard Delay);
        Task DeleteDelayAsync(string code);
    }
}
