using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IWilayaRepo
    {
        Task<IEnumerable<Wilaya>> GetAllWilayas();
        Task CreateWilaya(Wilaya wil);
        Task<Wilaya> GetWilaya(string code);
        Task UpdateWilaya(Wilaya wil);
        Task DeleteWilaya(string code);
    }
}
