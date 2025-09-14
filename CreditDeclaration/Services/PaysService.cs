using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using CreditDeclaration.Interface;

namespace CreditDeclaration.Services
{
    public class PaysService : IPaysService
    {
        private readonly IPaysRepo _countryRepo;// Repository instance for database operations

        public PaysService(IPaysRepo countryRepo)
        {
            _countryRepo = countryRepo; // Injecting the repository via constructor
        }

        // Retrieves all products, converts them to DTOs, and returns the list
        public async Task<IEnumerable<Pays>> GetAllCountriesAsync()
        {
            var countries = await _countryRepo.GetAllCountries(); // Fetch all products from repository

            // Convert each product entity into a ProductResponseDto and return the list
            return countries.Select(a => new Pays
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<Pays> GetCountryAsync(string code)
        {
            var var = await _countryRepo.GetCountry(code); // Fetch product by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("country not found");

            // Convert entity to DTO and return it
            return new Pays
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateCountryAsync(Pays country)
        {
            // Convert DTO to entity
            var var = new Pays
            {
                Code = country.Code,
                Domaine = country.Domaine,
                Descriptif = country.Descriptif
            };

            // Add the new product to the database
            await _countryRepo.CreateCountry(var);
        }

        // Updates an existing product with new data
        public async Task UpdateCountryAsync(string code, Pays country)
        {
            var var = await _countryRepo.GetCountry(code); // Fetch the product by ID

            // If the product does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("country not found");

            // Update fields with new values from DTO
            if (var.Code == country.Code)
            {
                var.Descriptif = country.Descriptif;

                // Save the updated in the database
                await _countryRepo.UpdateCountry(var);
            }
            else
            {
                await CreateCountryAsync(country);
                await DeleteCountryAsync(code);
            }
        }

        // Deletes by ID
        public async Task DeleteCountryAsync(string code)
        {
            var var = await _countryRepo.GetCountry(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("country not found");

            // Delete from the database
            await _countryRepo.DeleteCountry(code);
        }
    }
}
