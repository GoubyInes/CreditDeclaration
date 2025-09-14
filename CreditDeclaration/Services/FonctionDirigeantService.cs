using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class FonctionDirigeantService : IFonctionDirigeantService
    {
        private readonly IFonctionDirigeantRepo _functionRepo;// Repository instance for database operations

        public FonctionDirigeantService(IFonctionDirigeantRepo functionRepo)
        {
            _functionRepo = functionRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<FonctionDirigeant>> GetAllFunctionsAsync()
        {
            var functions = await _functionRepo.GetAllFunctions(); // Fetch all from repository

            // Convert each  entity into a ProductResponseDto and return the list
            return functions.Select(a => new FonctionDirigeant
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<FonctionDirigeant> GetFunctionAsync(string code)
        {
            var var = await _functionRepo.GetFunction(code); // Fetch  by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("function not found");

            // Convert entity to DTO and return it
            return new FonctionDirigeant
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateFunctionAsync(FonctionDirigeant function)
        {
            // Convert DTO to entity
            var var = new FonctionDirigeant
            {
                Code = function.Code,
                Domaine = function.Domaine,
                Descriptif = function.Descriptif
            };

            // Add the new  to the database
            await _functionRepo.CreateFunction(var);
        }

        // Updates an existing  with new data
        public async Task UpdateFunctionAsync(string code, FonctionDirigeant function)
        {
            var var = await _functionRepo.GetFunction(code); // Fetch the  by ID

            // If the  does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("function not found");

            // Update fields with new values from DTO
            if(var.Code == function.Code)
            {
                var.Domaine = function.Domaine;
                var.Descriptif = function.Descriptif;

                // Save the updated in the database
                await _functionRepo.UpdateFunction(var);
            }
            else
            {
                await CreateFunctionAsync(function);
                await DeleteFunctionAsync(code);
            }
           
        }

        // Deletes by ID
        public async Task DeleteFunctionAsync(string code)
        {
            var var = await _functionRepo.GetFunction(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("function not found");

            // Delete from the database
            await _functionRepo.DeleteFunction(code);
        }
    }
}
