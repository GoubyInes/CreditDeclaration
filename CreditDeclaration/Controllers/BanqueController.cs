using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class BanqueController : ControllerBase
    {
        private readonly IBanqueService _bankService; // Service instance for business logic

        public BanqueController(IBanqueService bankService)
        {
            _bankService = bankService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _bankService.GetAllBanksAsync(); // Calls service to get all 
            return Ok(activities); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var bank = await _bankService.GetBankAsync(code); // Calls service to fetcht by ID
                return Ok(bank); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(Banque bank)
        {
            await _bankService.CreateBankAsync(bank); // Calls service to add a new 
            return Ok(bank); //CreatedAtAction(nameof(GetById), new { code = bank.Code }, bank);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Banque bank)
        {
            try
            {
                await _bankService.UpdateBankAsync(id, bank); // Calls service to update 
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
                await _bankService.DeleteBankAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

