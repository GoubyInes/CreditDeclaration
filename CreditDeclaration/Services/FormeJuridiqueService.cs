using CreditDeclaration.Models;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class FormeJuridiqueService : IFormeJuridiqueService
    {
        private readonly IFormeJuridiqueRepo _formRepo;// Repository instance for database operations

        public FormeJuridiqueService(IFormeJuridiqueRepo formRepo)
        {
            _formRepo = formRepo; // Injecting the repository via constructor
        }

        // Retrieves all converts them to DTOs, and returns the list
        public async Task<IEnumerable<FormeJuridique>> GetAllFormsAsync()
        {
            var forms = await _formRepo.GetAllForms(); // Fetch all from repository

            // Convert each  entity into a ProductResponseDto and return the list
            return forms.Select(a => new FormeJuridique
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<FormeJuridique> GetFormAsync(string code)
        {
            var var = await _formRepo.GetForm(code); // Fetch  by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Form not found");

            // Convert entity to DTO and return it
            return new FormeJuridique
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateFormAsync(FormeJuridique Form)
        {
            // Convert DTO to entity
            var var = new FormeJuridique
            {
                Code = Form.Code,
                Domaine = Form.Domaine,
                Descriptif = Form.Descriptif
            };

            // Add the new  to the database
            await _formRepo.CreateForm(var);
        }

        // Updates an existing  with new data
        public async Task UpdateFormAsync(string code, FormeJuridique Form)
        {
            var var = await _formRepo.GetForm(code); // Fetch the by ID

            // If the  does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Form not found");

            // Update fields with new values from DTO
            if(var.Code == Form.Code)
            {
                var.Domaine = Form.Domaine;
                var.Descriptif = Form.Descriptif;

                // Save the updated in the database
                await _formRepo.UpdateForm(var);
            }
            else
            {
                await CreateFormAsync(Form);
                await DeleteFormAsync(code);
            }
            
        }

        // Deletes by ID
        public async Task DeleteFormAsync(string code)
        {
            var var = await _formRepo.GetForm(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Form not found");

            // Delete from the database
            await _formRepo.DeleteForm(code);
        }
    }
}
