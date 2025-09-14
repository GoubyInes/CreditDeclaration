using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class WilayaService : IWilayaService
    {
        private readonly IWilayaRepo _wilayaRepo;// Repository instance for database operations

        public WilayaService(IWilayaRepo wilayaRepo)
        {
            _wilayaRepo = wilayaRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<Wilaya>> GetAllWilayasAsync()
        {
            var wilayas = await _wilayaRepo.GetAllWilayas(); // Fetch all from repository

            // Convert each  entity into a ResponseDto and return the list
            return wilayas.Select(a => new Wilaya
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<Wilaya> GetWilayaAsync(string code)
        {
            var var = await _wilayaRepo.GetWilaya(code); // Fetch by ID

            // If the is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Wilaya not found");

            // Convert entity to DTO and return it
            return new Wilaya
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateWilayaAsync(Wilaya wil)
        {
            // Convert DTO to entity
            var var = new Wilaya
            {
                Code = wil.Code,
                Domaine = wil.Domaine,
                Descriptif = wil.Descriptif
            };

            // Add the new  to the database
            await _wilayaRepo.CreateWilaya(var);
        }

        // Updates an existing  with new data
        public async Task UpdateWilayaAsync(string code, Wilaya activity)
        {
            var var = await _wilayaRepo.GetWilaya(code); // Fetch the by ID

            // If the does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Activity not found");

            // Update fields with new values from DTO
            if (var.Code == activity.Code)
            {
                var.Domaine = activity.Domaine;
                var.Descriptif = activity.Descriptif;

                // Save the updated in the database
                await _wilayaRepo.UpdateWilaya(var);
            }
            else {
                await CreateWilayaAsync(activity);
                await DeleteWilayaAsync(code);
            }
        }

        // Deletes by ID
        public async Task DeleteWilayaAsync(string code)
        {
            var var = await _wilayaRepo.GetWilaya(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Wilaya not found");

            // Delete from the database
            await _wilayaRepo.DeleteWilaya(code);
        }
    }
}
