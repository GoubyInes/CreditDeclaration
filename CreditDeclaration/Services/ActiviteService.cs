using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class ActiviteService : IActiviteService
    {
        private readonly IActiviteRepo _activiteRepo;// Repository instance for database operations

        public ActiviteService(IActiviteRepo activiteRepo)
        {
            _activiteRepo = activiteRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<Activite>> GetAllActivitiesAsync()
        {
            var activities = await _activiteRepo.GetAllActivities(); // Fetch all from repository

            // Convert each  entity into a ResponseDto and return the list
            return activities.Select(a => new Activite
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<Activite> GetActivityAsync(string code)
        {
            var var = await _activiteRepo.GetActivity(code); // Fetch by ID

            // If the is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Activity not found");

            // Convert entity to DTO and return it
            return new Activite
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateActivityAsync(Activite activity)
        {
            // Convert DTO to entity
            var var = new Activite
            {
                Code = activity.Code,
                Domaine = activity.Domaine,
                Descriptif = activity.Descriptif
            };

            // Add the new  to the database
            await _activiteRepo.CreateActivity(var);
        }

        // Updates an existing  with new data
        public async Task UpdateActivityAsync(string code, Activite activity)
        {
            var var = await _activiteRepo.GetActivity(code); // Fetch the by ID

            // If the does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Activity not found");

            // Update fields with new values from DTO
            if (var.Code == activity.Code)
            {
                var.Domaine = activity.Domaine;
                var.Descriptif = activity.Descriptif;

                // Save the updated in the database
                await _activiteRepo.UpdateActivity(var);
            }
            else {
                await CreateActivityAsync(activity);
                await DeleteActivityAsync(code);
            }
        }

        // Deletes by ID
        public async Task DeleteActivityAsync(string code)
        {
            var var = await _activiteRepo.GetActivity(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Activity not found");

            // Delete from the database
            await _activiteRepo.DeleteActivity(code);
        }
    }
}
