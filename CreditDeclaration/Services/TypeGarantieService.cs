using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using System;

namespace CreditDeclaration.Services
{
    public class TypeGarantieService : ITypeGarantieService
    {
        private readonly ITypeGarantieRepo _collateralRepo;// Repository instance for database operations

        public TypeGarantieService(ITypeGarantieRepo collateralRepo)
        {
            _collateralRepo = collateralRepo; // Injecting the repository via constructor
        }

        // Retrieves all s, converts them to DTOs, and returns the list
        public async Task<IEnumerable<TypeGarantie>> GetAllCollateralsAsync()
        {
            var activities = await _collateralRepo.GetAllCollaterals(); // Fetch all s from repository

            // Convert each  entity into a ResponseDto and return the list
            return activities.Select(a => new TypeGarantie
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<TypeGarantie> GetCollateralAsync(string code)
        {
            var var = await _collateralRepo.GetCollateral(code); // Fetch  by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Collateral not found");

            // Convert entity to DTO and return it
            return new TypeGarantie
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateCollateralAsync(TypeGarantie Collateral)
        {
            // Convert DTO to entity
            var var = new TypeGarantie
            {
                Code = Collateral.Code,
                Domaine = Collateral.Domaine,
                Descriptif = Collateral.Descriptif
            };

            // Add the new  to the database
            await _collateralRepo.CreateCollateral(var);
        }

        // Updates an existing  with new data
        public async Task UpdateCollateralAsync(string code, TypeGarantie Collateral)
        {
            var var = await _collateralRepo.GetCollateral(code); // Fetch the  by ID

            // If the  does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Collateral not found");

            // Update fields with new values from DTO
            if (var.Code == Collateral.Code)
            {
                var.Domaine = Collateral.Domaine;
                var.Descriptif = Collateral.Descriptif;

                // Save the updated in the database
                await _collateralRepo.UpdateCollateral(var);
            }
            else
            {
                await CreateCollateralAsync(Collateral);
                await DeleteCollateralAsync(code);
            }
        }

        // Deletes by ID
        public async Task DeleteCollateralAsync(string code)
        {
            var var = await _collateralRepo.GetCollateral(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Collateral not found");

            // Delete from the database
            await _collateralRepo.DeleteCollateral(code);
        }
    }
}
