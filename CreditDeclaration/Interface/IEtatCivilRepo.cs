using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface IEtatCivilRepo
    {
        Task<IEnumerable<EtatCivil>> GetAllStatus();
        Task CreateStatus(EtatCivil Bank);
        Task<EtatCivil> GetStatus(string code);
        Task UpdateStatus(EtatCivil Bank);
        Task DeleteStatus(string code);
    }
}
