
using CreditDeclaration.Models;
namespace CreditDeclaration.Interface
{
    public interface ITypeGarantieRepo
    {
        Task<IEnumerable<TypeGarantie>> GetAllCollaterals();
        Task CreateCollateral(TypeGarantie collateral);
        Task<TypeGarantie> GetCollateral(string code);
        Task UpdateCollateral(TypeGarantie collateral);
        Task DeleteCollateral(string code);
    }
}
