using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class ClasseRetardService : IClasseRetardService
    {
        private readonly IClasseRetardRepo _delayRepo;// Repository instance for database operations

        public ClasseRetardService(IClasseRetardRepo delayRepo)
        {
            _delayRepo = delayRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<ClasseRetard>> GetAllDelaysAsync()
        {
            var delays = await _delayRepo.GetAllDelays(); // Fetch all from repository

            // Convert each entity into a ProductResponseDto and return the list
            return delays.Select(a => new ClasseRetard
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<ClasseRetard> GetDelayAsync(string code)
        {
            var var = await _delayRepo.GetDelay(code); // Fetch  by ID

            // If the  is not found,throw an exception
            if (var== null)
                throw new KeyNotFoundException("Delay not found");

            // Convert entity to DTO and return it
            return new ClasseRetard
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateDelayAsync(ClasseRetard delay)
        {
            // Convert DTO to entity
            var var = new ClasseRetard
            {
                Code = delay.Code,
                Domaine = delay.Domaine,
                Descriptif = delay.Descriptif
            };

            // Add the new to the database
            await _delayRepo.CreateDelay(var);
        }

        // Updates an existing with new data
        public async Task UpdateDelayAsync(string code, ClasseRetard delay)
        {
            var var = await _delayRepo.GetDelay(code); // Fetch the  by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Delay not found");

            // Update fields with new values from DTO
            if (var.Code == delay.Code)
            {
                var.Domaine = delay.Domaine;
                var.Descriptif = delay.Descriptif;

                // Save the updated in the database
                await _delayRepo.UpdateDelay(var);

            }
            else
            {
                await DeleteDelayAsync(code);
                await CreateDelayAsync(delay);
            }
        }

        // Deletes by ID
        public async Task DeleteDelayAsync(string code)
        {
            var var = await _delayRepo.GetDelay(code); // Fetch by ID

            // If does not exist,throw an exception
            if (var == null)
                throw new KeyNotFoundException("Delay not found");

            // Delete from the database
            await _delayRepo.DeleteDelay(code);
        }
    }
}
