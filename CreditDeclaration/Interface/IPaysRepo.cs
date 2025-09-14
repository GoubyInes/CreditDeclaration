using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IPaysRepo
    {
        Task<IEnumerable<Pays>> GetAllCountries();
        Task CreateCountry(Pays country);
        Task<Pays> GetCountry(string code);
        Task UpdateCountry(Pays country);
        Task DeleteCountry(string code);
    }
}
