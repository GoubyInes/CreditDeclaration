using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface ICommuneRepo
    {
        Task<IEnumerable<Commune>> GetAllCommunes();
        Task CreateCommune(Commune com);
        Task<Commune> GetCommune(string code, string domaine);
        Task UpdateCommune(Commune com);
        Task DeleteCommune(string code, string domaine);
    }
}
