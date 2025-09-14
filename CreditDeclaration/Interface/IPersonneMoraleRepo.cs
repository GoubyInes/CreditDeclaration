using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IPersonneMoraleRepo
    {
        Task<IEnumerable<PersonneMorale>> GetAllPersonMorals();
        Task CreatePersonMoral(PersonneMorale PersonMoral);
        Task<PersonneMorale> GetPersonMoral(int id);
        Task UpdatePersonMoral(PersonneMorale PersonMoral);
        Task DeletePersonMoral(int id);
    }
}
