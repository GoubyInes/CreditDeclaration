using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class DureeService : IDureeService
    {
        private readonly IDureeRepo _durationRepo;// Repository instance for database operations

        public DureeService(IDureeRepo durationRepo)
        {
            _durationRepo = durationRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<DureeCredit>> GetAllDurationsAsync()
        {
            var durations = await _durationRepo.GetAllDurations(); // Fetch all from repository

            // Convert each entity into a ProductResponseDto and return the list
            return durations.Select(a => new DureeCredit
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<DureeCredit> GetDurationAsync(string code)
        {
            var var = await _durationRepo.GetDuration(code); // Fetch  by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Duration not found");

            // Convert entity to DTO and return it
            return new DureeCredit
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateDurationAsync(DureeCredit duration)
        {
            // Convert DTO to entity
            var var = new DureeCredit
            {
                Code = duration.Code,
                Domaine = duration.Domaine,
                Descriptif = duration.Descriptif
            };

            // Add the new to the database
            await _durationRepo.CreateDuration(var);
        }

        // Updates an existing with new data
        public async Task UpdateDurationAsync(string code, DureeCredit duration)
        {
            var var = await _durationRepo.GetDuration(code); // Fetch the  by ID

            // If the  does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("duration not found");

            // Update fields with new values from DTO
            if (var.Code == duration.Code)
            {
                var.Domaine = duration.Domaine;
                var.Descriptif = duration.Descriptif;
                // Save the updated in the database
                await _durationRepo.UpdateDuration(var);
            }
            else
            {
                await DeleteDurationAsync(code);
                await CreateDurationAsync(duration);
            }
        }

        // Deletes by ID
        public async Task DeleteDurationAsync(string code)
        {
            var var = await _durationRepo.GetDuration(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("duration not found");

            // Delete from the database
            await _durationRepo.DeleteDuration(code);
        }
    }
}
