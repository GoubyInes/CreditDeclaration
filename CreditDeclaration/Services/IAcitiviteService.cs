using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IActiviteService
    {
        Task<IEnumerable<Activite>> GetAllActivitiesAsync();
        Task CreateActivityAsync(Activite activity);
        Task<Activite> GetActivityAsync(string code);
        Task UpdateActivityAsync(string code,Activite activity);
        Task DeleteActivityAsync(string code);
    }
}
