using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IClasseRetardRepo
    {
        Task<IEnumerable<ClasseRetard>> GetAllDelays();
        Task CreateDelay(ClasseRetard Delay);
        Task<ClasseRetard> GetDelay(string code);
        Task UpdateDelay(ClasseRetard Delay);
        Task DeleteDelay(string code);
    }
}
