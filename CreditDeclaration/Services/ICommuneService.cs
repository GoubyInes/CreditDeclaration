using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface ICommuneService
    {
        Task<IEnumerable<Commune>> GetAllCommunesAsync();
        Task CreateCommuneAsync(Commune com);
        Task<Commune> GetCommuneAsync(string code, string domaine);
        Task UpdateCommuneAsync(string code, string domaine, Commune com);
        Task DeleteCommuneAsync(string code, string domaine);
    }
}
