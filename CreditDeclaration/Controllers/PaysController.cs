using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class PaysController : ControllerBase
    {
        private readonly IPaysService _countryService; // Service instance for business logic

        public PaysController(IPaysService countryService)
        {
            _countryService = countryService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryService.GetAllCountriesAsync(); // Calls service to get all 
            return Ok(countries); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var bank = await _countryService.GetCountryAsync(code); // Calls service to fetcht by ID
                return Ok(bank); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(Pays country)
        {
            await _countryService.CreateCountryAsync(country); // Calls service to add a new 
            return Ok(country); //CreatedAtAction(nameof(GetById), new { code = bank.Code }, bank);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Pays country)
        {
            try
            {
                await _countryService.UpdateCountryAsync(id, country); // Calls service to update 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP DELETE request to delete by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _countryService.DeleteCountryAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

