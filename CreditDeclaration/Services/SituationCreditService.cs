using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class SituationCreditService : ISituationCreditService
    {
        private readonly ISituationCreditRepo _situationRepo;// Repository instance for database operations

        public SituationCreditService(ISituationCreditRepo situationRepo)
        {
            _situationRepo = situationRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<SituationCredit>> GetAllSituationsAsync()
        {
            var Situations = await _situationRepo.GetAllSituations(); // Fetch all from repository

            // Convert each  entity into a ResponseDto and return the list
            return Situations.Select(a => new SituationCredit
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<SituationCredit> GetSituationAsync(string code)
        {
            var var = await _situationRepo.GetSituation(code); // Fetch by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Situation not found");

            // Convert entity to DTO and return it
            return new SituationCredit
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateSituationAsync(SituationCredit Situation)
        {
            // Convert DTO to entity
            var var = new SituationCredit
            {
                Code = Situation.Code,
                Domaine = Situation.Domaine,
                Descriptif = Situation.Descriptif
            };
            // Add the new to the database
            await _situationRepo.CreateSituation(var);
        }

        // Updates an existing with new data
        public async Task UpdateSituationAsync(string code, SituationCredit Situation)
        {
            var var = await _situationRepo.GetSituation(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Situation not found");

            // Update fields with new values from DTO
            if (var.Code == Situation.Code){
                var.Domaine = Situation.Domaine;
                var.Descriptif = Situation.Descriptif;
                // Save the updated in the database
                await _situationRepo.UpdateSituation(var);
            }
            else 
            {
                await DeleteSituationAsync(code);
                await CreateSituationAsync(Situation);
            }
           
        }

        // Deletes by ID
        public async Task DeleteSituationAsync(string code)
        {
            var var = await _situationRepo.GetSituation(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Situation not found");

            // Delete from the database
            await _situationRepo.DeleteSituation(code);
        }
    }
}
