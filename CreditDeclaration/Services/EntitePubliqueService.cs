using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class EntitePubliqueService : IEntitePubliqueService
    {
        private readonly IEntitePubliqueRepo _entityRepo;// Repository instance for database operations

        public EntitePubliqueService(IEntitePubliqueRepo entityRepo)
        {
            _entityRepo = entityRepo; // Injecting the repository via constructor
        }

        // Retrieves all products, converts them to DTOs, and returns the list
        public async Task<IEnumerable<EntitePublique>> GetAllEntitiesAsync()
        {
            var entities = await _entityRepo.GetAllEntities(); // Fetch all products from repository

            // Convert each product entity into a ProductResponseDto and return the list
            return entities.Select(a => new EntitePublique
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<EntitePublique> GetEntityAsync(string code)
        {
            var var = await _entityRepo.GetEntity(code); // Fetch product by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Entity not found");

            // Convert entity to DTO and return it
            return new EntitePublique
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateEntityAsync(EntitePublique entity)
        {
            // Convert DTO to entity
            var var = new EntitePublique
            {
                Code = entity.Code,
                Domaine = entity.Domaine,
                Descriptif = entity.Descriptif
            };

            // Add the new product to the database
            await _entityRepo.CreateEntity(var);
        }

        // Updates an existing product with new data
        public async Task UpdateEntityAsync(string code, EntitePublique entity)
        {
            var var = await _entityRepo.GetEntity(code); // Fetch the product by ID

            // If the product does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("entity not found");

            // Update fields with new values from DTO
            if (var.Code == entity.Code)
            {
                var.Domaine = entity.Domaine;
                var.Descriptif = entity.Descriptif;
                // Save the updated in the database
                await _entityRepo.UpdateEntity(var);
            }
            else
            {
                await DeleteEntityAsync(code);
                await CreateEntityAsync(entity);
            }
        }

        // Deletes by ID
        public async Task DeleteEntityAsync(string code)
        {
            var var = await _entityRepo.GetEntity(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("entity not found");

            // Delete from the database
            await _entityRepo.DeleteEntity(code);
        }
    }
}
