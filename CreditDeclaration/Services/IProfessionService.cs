using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IProfessionService
    {
        Task<IEnumerable<Profession>> GetAllProfessionsAsync();
        Task CreateProfessionAsync(Profession profession);
        Task<Profession> GetProfessionAsync(string code);
        Task UpdateProfessionAsync(string code, Profession profession);
        Task DeleteProfessionAsync(string code);
    }
}
