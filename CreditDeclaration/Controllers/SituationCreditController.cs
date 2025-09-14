using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class SituationCreditController : ControllerBase
    {
        private readonly ISituationCreditService _situationService; // Service instance for business logic

        public SituationCreditController(ISituationCreditService situationService)
        {
            _situationService = situationService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var situations = await _situationService.GetAllSituationsAsync(); // Calls service to get all 
            return Ok(situations); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var Situation = await _situationService.GetSituationAsync(code); // Calls service to fetcht by ID
                return Ok(Situation); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(SituationCredit Situation)
        {
            await _situationService.CreateSituationAsync(Situation); // Calls service to add a new 
            return Ok(Situation); //CreatedAtAction(nameof(GetById), new { code = Situation.Code }, Situation);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SituationCredit Situation)
        {
            try
            {
                await _situationService.UpdateSituationAsync(id, Situation); // Calls service to update 
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
                await _situationService.DeleteSituationAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

