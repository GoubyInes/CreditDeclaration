using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class CommuneService : ICommuneService
    {
        private readonly ICommuneRepo _communeRepo;// Repository instance for database operations

        public CommuneService(ICommuneRepo communeRepo)
        {
            _communeRepo = communeRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<Commune>> GetAllCommunesAsync()
        {
            var communes = await _communeRepo.GetAllCommunes(); // Fetch all from repository

            // Convert each  entity into a ResponseDto and return the list
            return communes.Select(a => new Commune
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<Commune> GetCommuneAsync(string code, string domaine)
        {
            var var = await _communeRepo.GetCommune(code, domaine); // Fetch by ID

            // If the is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Commune not found");

            // Convert entity to DTO and return it
            return new Commune
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateCommuneAsync(Commune commune)
        {
            // Convert DTO to entity
            var var = new Commune
            {
                Code = commune.Code,
                Domaine = commune.Domaine,
                Descriptif = commune.Descriptif
            };

            // Add the new  to the database
            await _communeRepo.CreateCommune(var);
        }

        // Updates an existing  with new data
        public async Task UpdateCommuneAsync(string code, string domaine, Commune commune)
        {
            var var = await _communeRepo.GetCommune(code, domaine); // Fetch the by ID

            // If the does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Commune not found");

            // Update fields with new values from DTO
            if ((var.Code == commune.Code) && (var.Domaine == commune.Domaine))
            {
                var.Descriptif = commune.Descriptif;

                // Save the updated in the database
                await _communeRepo.UpdateCommune(var);
            }
            else {
                await CreateCommuneAsync(commune);
                await DeleteCommuneAsync(code, domaine);
            }
        }

        // Deletes by ID
        public async Task DeleteCommuneAsync(string code, string domaine)
        {
            var var = await _communeRepo.GetCommune(code, domaine); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("commune not found");

            // Delete from the database
            await _communeRepo.DeleteCommune(code, domaine);
        }
    }
}
