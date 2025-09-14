using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class SourceInformationService : ISourceInformationService
    {
        private readonly ISourceInformationRepo _sourceRepo;// Repository instance for database operations

        public SourceInformationService(ISourceInformationRepo sourceRepo)
        {
            _sourceRepo = sourceRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<SourceInformationCredit>> GetAllSourcesAsync()
        {
            var Sources = await _sourceRepo.GetAllSources(); // Fetch all from repository

            // Convert each  entity into a ResponseDto and return the list
            return Sources.Select(a => new SourceInformationCredit
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<SourceInformationCredit> GetSourceAsync(string code)
        {
            var var = await _sourceRepo.GetSource(code); // Fetch by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Source not found");

            // Convert entity to DTO and return it
            return new SourceInformationCredit
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateSourceAsync(SourceInformationCredit Source)
        {
            // Convert DTO to entity
            var var = new SourceInformationCredit
            {
                Code = Source.Code,
                Domaine = Source.Domaine,
                Descriptif = Source.Descriptif
            };
            // Add the new to the database
            await _sourceRepo.CreateSource(var);
        }

        // Updates an existing with new data
        public async Task UpdateSourceAsync(string code, SourceInformationCredit Source)
        {
            var var = await _sourceRepo.GetSource(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Source not found");

            // Update fields with new values from DTO
            if (var.Code == Source.Code){
                var.Domaine = Source.Domaine;
                var.Descriptif = Source.Descriptif;
                // Save the updated in the database
                await _sourceRepo.UpdateSource(var);
            }
            else 
            {
                await DeleteSourceAsync(code);
                await CreateSourceAsync(Source);
            }
           
        }

        // Deletes by ID
        public async Task DeleteSourceAsync(string code)
        {
            var var = await _sourceRepo.GetSource(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Source not found");

            // Delete from the database
            await _sourceRepo.DeleteSource(code);
        }
    }
}
