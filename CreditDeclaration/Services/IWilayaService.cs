using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface IWilayaService
    {
        Task<IEnumerable<Wilaya>> GetAllWilayasAsync();
        Task CreateWilayaAsync(Wilaya wil);
        Task<Wilaya> GetWilayaAsync(string code);
        Task UpdateWilayaAsync(string code, Wilaya wil);
        Task DeleteWilayaAsync(string code);
    }
}
