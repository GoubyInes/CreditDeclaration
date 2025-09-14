using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class MonnaieService : IMonnaieService
    {
        private readonly IMonnaieRepo _changeRepo;// Repository instance for database operations

        public MonnaieService(IMonnaieRepo changeRepo)
        {
            _changeRepo = changeRepo; // Injecting the repository via constructor
        }

        // Retrieves all products, converts them to DTOs, and returns the list
        public async Task<IEnumerable<Monnaie>> GetAllChangesAsync()
        {
            var changes = await _changeRepo.GetAllChanges(); // Fetch all products from repository

            // Convert each product entity into a ProductResponseDto and return the list
            return changes.Select(a => new Monnaie
            {
                Code = a.Code,
                Devise = a.Devise,
                Entite= a.Entite
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<Monnaie> GetChangeAsync(string code)
        {
            var var = await _changeRepo.GetChange(code); // Fetch product by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Monnaie not found");

            // Convert entity to DTO and return it
            return new Monnaie
            {
                Code = var.Code,
                Devise = var.Devise,
                Entite = var.Entite
            };

        }

        // Adds a new using a request DTO
        public async Task CreateChangeAsync(Monnaie Monnaie)
        {
            // Convert DTO to entity
            var var = new Monnaie
            {
                Code = Monnaie.Code,
                Devise = Monnaie.Devise,
                Entite = Monnaie.Entite
            };

            // Add the new product to the database
            await _changeRepo.CreateChange(var);
        }

        // Updates an existing product with new data
        public async Task UpdateChangeAsync(string code, Monnaie monnaie)
        {
            var var = await _changeRepo.GetChange(code); // Fetch the product by ID

            // If the product does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Monnaie not found");

            // Update fields with new values from DTO
           if( var.Code == monnaie.Code)
           {
                var.Devise = monnaie.Devise;
                var.Entite = monnaie.Entite;

                // Save the updated in the database
                await _changeRepo.UpdateChange(var);
           }
            else
            {
                await DeleteChangeAsync(code);
                await CreateChangeAsync(monnaie);
            }
            
        }

        // Deletes by ID
        public async Task DeleteChangeAsync(string code)
        {
            var var = await _changeRepo.GetChange(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Monnaie not found");

            // Delete from the database
            await _changeRepo.DeleteChange(code);
        }
    }
}
