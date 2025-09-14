using CreditDeclaration.Interface;
using CreditDeclaration.Modals;
using CreditDeclaration.Models;


namespace CreditDeclaration.Services
{
    public class PersonneMoraleService : IPersonneMoraleService
    {
        private readonly IPersonneMoraleRepo _personRepo;// Repository instance for database operations

        public PersonneMoraleService(IPersonneMoraleRepo personRepo)
        {
            _personRepo = personRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<PersonneMorale>> GetAllPersonMoralsAsync()
        {
            var persons = await _personRepo.GetAllPersonMorals(); // Fetch all from repository

            // Convert each  entity into a ResponseDto and return the list
            return persons.Select(a => new PersonneMorale
            {
               // Code = a.Code,
               // Domaine = a.Domaine,
               // Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<PersonneMorale> GetPersonMoralAsync(int id)
        {
            var var = await _personRepo.GetPersonMoral(id); // Fetch by ID

            // If the is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Person not found");

            // Convert entity to DTO and return it
            return new PersonneMorale
            {
               // Code = var.Code,
               // Domaine = var.Domaine,
               // Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreatePersonMoralAsync(PersonneMorale person)
        {
            // Convert DTO to entity
            var var = new PersonneMorale
            {
               // Code = activity.Code,
               // Domaine = activity.Domaine,
              //  Descriptif = activity.Descriptif
            };

            // Add the new  to the database
            await _personRepo.CreatePersonMoral(var);
        }

        // Updates an existing  with new data
        public async Task UpdatePersonMoralAsync(PersonneMorale person)
        {
           // var var = await _personRepo.GetPersonMoral(person.Id); // Fetch the by ID

            // If the does not exist, throw an exception
          /*  if (var == null)
                throw new KeyNotFoundException("Activity not found");*/

            // Update fields with new values from DTO
           
               // var.Domaine = activity.Domaine;
               // var.Descriptif = activity.Descriptif;

                // Save the updated in the database
            await _personRepo.UpdatePersonMoral(person);
           
        }

        // Deletes by ID
        public async Task DeletePersonMoralAsync(int id)
        {
            var var = await _personRepo.GetPersonMoral(id); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Person not found");

            // Delete from the database
            await _personRepo.DeletePersonMoral(id);
        }
    }
}
