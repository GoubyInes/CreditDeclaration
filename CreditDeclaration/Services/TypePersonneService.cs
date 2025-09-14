using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class TypePersonneService : ITypePersonneService
    {
        private readonly ITypePersonneRepo _personRepo;// Repository instance for database operations

        public TypePersonneService(ITypePersonneRepo personRepo)
        {
            _personRepo = personRepo; // Injecting the repository via constructor
        }

        // Retrieves all , converts them to DTOs, and returns the list
        public async Task<IEnumerable<TypePersonne>> GetAllPersonsAsync()
        {
            var persons = await _personRepo.GetAllPersons(); // Fetch all  from repository

            // Convert each  entity into a ResponseDto and return the list
            return persons.Select(a => new TypePersonne
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<TypePersonne> GetPersonAsync(string code)
        {
            var var = await _personRepo.GetPerson(code); // Fetch  by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Person not found");

            // Convert entity to DTO and return it
            return new TypePersonne
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreatePersonAsync(TypePersonne Person)
        {
            // Convert DTO to entity
            var var = new TypePersonne
            {
                Code = Person.Code,
                Domaine = Person.Domaine,
                Descriptif = Person.Descriptif
            };

            // Add the new  to the database
            await _personRepo.CreatePerson(var);
        }

        // Updates an existing  with new data
        public async Task UpdatePersonAsync(string code, TypePersonne Person)
        {
            var var = await _personRepo.GetPerson(code); // Fetch the  by ID

            // If the  does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Person not found");

            // Update fields with new values from DTO
            if (var.Code == Person.Code)
            {
                var.Domaine = Person.Domaine;
                var.Descriptif = Person.Descriptif;

                // Save the updated in the database
                await _personRepo.UpdatePerson(var);
            }
            else
            {
                await CreatePersonAsync(Person);
                await DeletePersonAsync(code);
            }
        }

        // Deletes by ID
        public async Task DeletePersonAsync(string code)
        {
            var var = await _personRepo.GetPerson(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Person not found");

            // Delete from the database
            await _personRepo.DeletePerson(code);
        }
    }
}
