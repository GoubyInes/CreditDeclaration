using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepo _ProfessionRepo;// Repository instance for database operations

        public ProfessionService(IProfessionRepo ProfessionRepo)
        {
            _ProfessionRepo = ProfessionRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<Profession>> GetAllProfessionsAsync()
        {
            var Professions = await _ProfessionRepo.GetAllProfessions(); // Fetch all from repository

            // Convert each  entity into a ResponseDto and return the list
            return Professions.Select(a => new Profession
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<Profession> GetProfessionAsync(string code)
        {
            var var = await _ProfessionRepo.GetProfession(code); // Fetch by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Profession not found");

            // Convert entity to DTO and return it
            return new Profession
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateProfessionAsync(Profession Profession)
        {
            // Convert DTO to entity
            var var = new Profession
            {
                Code = Profession.Code,
                Domaine = Profession.Domaine,
                Descriptif = Profession.Descriptif
            };
            // Add the new to the database
            await _ProfessionRepo.CreateProfession(var);
        }

        // Updates an existing with new data
        public async Task UpdateProfessionAsync(string code, Profession Profession)
        {
            var var = await _ProfessionRepo.GetProfession(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Profession not found");

            // Update fields with new values from DTO
            if (var.Code == Profession.Code){
                var.Domaine = Profession.Domaine;
                var.Descriptif = Profession.Descriptif;
                // Save the updated in the database
                await _ProfessionRepo.UpdateProfession(var);
            }
            else 
            {
                await DeleteProfessionAsync(code);
                await CreateProfessionAsync(Profession);
            }
           
        }

        // Deletes by ID
        public async Task DeleteProfessionAsync(string code)
        {
            var var = await _ProfessionRepo.GetProfession(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Profession not found");

            // Delete from the database
            await _ProfessionRepo.DeleteProfession(code);
        }
    }
}
