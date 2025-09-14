using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using System.Reflection.Metadata;

namespace CreditDeclaration.Services
{
    public class TypeCreditService : ITypeCreditService
    {
        private readonly ITypeCreditRepo _typeRepo;// Repository instance for database operations

        public TypeCreditService(ITypeCreditRepo typeRepo)
        {
            _typeRepo = typeRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<TypeCredit>> GetAllTypesAsync()
        {
            var types = await _typeRepo.GetAllTypes(); // Fetch all s from repository

            // Convert each  entity into a ResponseDto and return the list
            return types.Select(a => new TypeCredit
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<TypeCredit> GetTypeAsync(string code)
        {
            var var = await _typeRepo.GetType(code); // Fetch  by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Type not found");

            // Convert entity to DTO and return it
            return new TypeCredit
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateTypeAsync(TypeCredit Type)
        {
            // Convert DTO to entity
            var var = new TypeCredit
            {
                Code = Type.Code,
                Domaine = Type.Domaine,
                Descriptif = Type.Descriptif
            };

            // Add the new  to the database
            await _typeRepo.CreateType(var);
        }

        // Updates an existing  with new data
        public async Task UpdateTypeAsync(string code, TypeCredit Type)
        {
            var var = await _typeRepo.GetType(code); // Fetch the  by ID

            // If the  does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Type not found");

            // Update fields with new values from DTO
            if (var.Code == Type.Code)
            {
                var.Domaine = Type.Domaine;
                var.Descriptif = Type.Descriptif;

                // Save the updated in the database
                await _typeRepo.UpdateType(var);
            }
            else
            {
                await CreateTypeAsync(Type);
                await DeleteTypeAsync(code);
            }
        }

        // Deletes by ID
        public async Task DeleteTypeAsync(string code)
        {
            var var = await _typeRepo.GetType(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Type not found");

            // Delete from the database
            await _typeRepo.DeleteType(code);
        }
    }
}
