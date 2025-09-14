using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IPaysService
    {
        Task<IEnumerable<Pays>> GetAllCountriesAsync();
        Task CreateCountryAsync(Pays country);
        Task<Pays> GetCountryAsync(string code);
        Task UpdateCountryAsync(string code, Pays country);
        Task DeleteCountryAsync(string code);
    }
}
