using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IActiviteRepo
    {
        Task<IEnumerable<Activite>> GetAllActivities();
        Task CreateActivity(Activite activity);
        Task<Activite> GetActivity(string code);
        Task UpdateActivity(Activite activity);
        Task DeleteActivity(string code);
    }
}
