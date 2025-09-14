using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class EtatCivilService : IEtatCivilService
    {
        private readonly IEtatCivilRepo _statusRepo;// Repository instance for database operations

        public EtatCivilService(IEtatCivilRepo statusRepo)
        {
            _statusRepo = statusRepo; // Injecting the repository via constructor
        }

        // Retrieves all products, converts them to DTOs, and returns the list
        public async Task<IEnumerable<EtatCivil>> GetAllStatusAsync()
        {
            var status = await _statusRepo.GetAllStatus(); // Fetch all products from repository

            // Convert each product entity into a ProductResponseDto and return the list
            return status.Select(a => new EtatCivil
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<EtatCivil> GetStatusAsync(string code)
        {
            var var = await _statusRepo.GetStatus(code); // Fetch product by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("status not found");

            // Convert entity to DTO and return it
            return new EtatCivil
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateStatusAsync(EtatCivil status)
        {
            // Convert DTO to entity
            var var = new EtatCivil
            {
                Code = status.Code,
                Domaine = status.Domaine,
                Descriptif = status.Descriptif
            };

            // Add the new product to the database
            await _statusRepo.CreateStatus(var);
        }

        // Updates an existing product with new data
        public async Task UpdateStatusAsync(string code, EtatCivil status)
        {
            var var = await _statusRepo.GetStatus(code); // Fetch the product by ID

            // If the product does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("status not found");

            // Update fields with new values from DTO
            if(var.Code == status.Code)
            {
                var.Domaine = status.Domaine;
                var.Descriptif = status.Descriptif;

                // Save the updated in the database
                await _statusRepo.UpdateStatus(var);
            }
            else
            {
                await CreateStatusAsync(status);
                await DeleteStatusAsync(code);
            }
           
        }

        // Deletes by ID
        public async Task DeleteStatusAsync(string code)
        {
            var var = await _statusRepo.GetStatus(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("status not found");

            // Delete from the database
            await _statusRepo.DeleteStatus(code);
        }
    }
}
