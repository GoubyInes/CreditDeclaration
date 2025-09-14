using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IPersonneMoraleService
    {
        Task<IEnumerable<PersonneMorale>> GetAllPersonMoralsAsync();
        Task CreatePersonMoralAsync(PersonneMorale PersonMoral);
        Task<PersonneMorale> GetPersonMoralAsync(int id);
        Task UpdatePersonMoralAsync(PersonneMorale PersonMoral);
        Task DeletePersonMoralAsync(int id);
    }
}
