using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class NiveauResponsabiliteService : INiveauResponsabiliteService
    {
        private readonly INiveauResponsabiliteRepo _levelRepo;// Repository instance for database operations

        public NiveauResponsabiliteService(INiveauResponsabiliteRepo levelRepo)
        {
            _levelRepo = levelRepo; // Injecting the repository via constructor
        }

        // Retrieves all products, converts them to DTOs, and returns the list
        public async Task<IEnumerable<NiveauResponsabilite>> GetAllLevelsAsync()
        {
            var activities = await _levelRepo.GetAllLevels(); // Fetch all products from repository

            // Convert each product entity into a ProductResponseDto and return the list
            return activities.Select(a => new NiveauResponsabilite
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<NiveauResponsabilite> GetLevelAsync(string code)
        {
            var var = await _levelRepo.GetLevel(code); // Fetch product by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Level not found");

            // Convert entity to DTO and return it
            return new NiveauResponsabilite
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateLevelAsync(NiveauResponsabilite Level)
        {
            // Convert DTO to entity
            var var = new NiveauResponsabilite
            {
                Code = Level.Code,
                Domaine = Level.Domaine,
                Descriptif = Level.Descriptif
            };

            // Add the new product to the database
            await _levelRepo.CreateLevel(var);
        }

        // Updates an existing product with new data
        public async Task UpdateLevelAsync(string code, NiveauResponsabilite Level)
        {
            var var = await _levelRepo.GetLevel(code); // Fetch the product by ID

            // If the product does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Level not found");

            // Update fields with new values from DTO
            if(var.Code != Level.Code)
            {
                var.Domaine = Level.Domaine;
                var.Descriptif = Level.Descriptif;
                // Save the updated in the database
                await _levelRepo.UpdateLevel(var);
            }
            else
            {
                await CreateLevelAsync(Level);
                await DeleteLevelAsync(code);
            }
            
        }

        // Deletes by ID
        public async Task DeleteLevelAsync(string code)
        {
            var var = await _levelRepo.GetLevel(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Level not found");

            // Delete from the database
            await _levelRepo.DeleteLevel(code);
        }
    }
}
