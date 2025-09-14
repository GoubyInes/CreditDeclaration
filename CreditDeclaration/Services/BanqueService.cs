using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class BanqueService : IBanqueService
    {
        private readonly IBanqueRepo _bankRepo;// Repository instance for database operations

        public BanqueService(IBanqueRepo bankRepo)
        {
            _bankRepo = bankRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<Banque>> GetAllBanksAsync()
        {
            var banks = await _bankRepo.GetAllBanks(); // Fetch all from repository

            // Convert each  entity into a ResponseDto and return the list
            return banks.Select(a => new Banque
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<Banque> GetBankAsync(string code)
        {
            var var = await _bankRepo.GetBank(code); // Fetch by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Bank not found");

            // Convert entity to DTO and return it
            return new Banque
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateBankAsync(Banque bank)
        {
            // Convert DTO to entity
            var var = new Banque
            {
                Code = bank.Code,
                Domaine = bank.Domaine,
                Descriptif = bank.Descriptif
            };
            // Add the new to the database
            await _bankRepo.CreateBank(var);
        }

        // Updates an existing with new data
        public async Task UpdateBankAsync(string code, Banque bank)
        {
            var var = await _bankRepo.GetBank(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Bank not found");

            // Update fields with new values from DTO
            if (var.Code == bank.Code){
                var.Domaine = bank.Domaine;
                var.Descriptif = bank.Descriptif;
                // Save the updated in the database
                await _bankRepo.UpdateBank(var);
            }
            else 
            {
                await DeleteBankAsync(code);
                await CreateBankAsync(bank);
            }
           
        }

        // Deletes by ID
        public async Task DeleteBankAsync(string code)
        {
            var var = await _bankRepo.GetBank(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Bank not found");

            // Delete from the database
            await _bankRepo.DeleteBank(code);
        }
    }
}
