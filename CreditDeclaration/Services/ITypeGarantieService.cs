
using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface ITypeGarantieService
    {
        Task<IEnumerable<TypeGarantie>> GetAllCollateralsAsync();
        Task CreateCollateralAsync(TypeGarantie collateral);
        Task<TypeGarantie> GetCollateralAsync(string code);
        Task UpdateCollateralAsync(string code, TypeGarantie collateral);
        Task DeleteCollateralAsync(string code);
    }
}
