using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IProfessionRepo
    {
        Task<IEnumerable<Profession>> GetAllProfessions();
        Task CreateProfession(Profession profession);
        Task<Profession> GetProfession(string code);
        Task UpdateProfession(Profession profession);
        Task DeleteProfession(string code);
    }
}
