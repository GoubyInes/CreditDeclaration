using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class FormeJuridiqueController : ControllerBase
    {
        private readonly IFormeJuridiqueService _formService; // Service instance for business logic

        public FormeJuridiqueController(IFormeJuridiqueService formService)
        {
            _formService = formService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var forms = await _formService.GetAllFormsAsync(); // Calls service to get all 
            return Ok(forms); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var form = await _formService.GetFormAsync(code); // Calls service to fetcht by ID
                return Ok(form); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(FormeJuridique form)
        {
            await _formService.CreateFormAsync(form); // Calls service to add a new 
            return Ok(form); //CreatedAtAction(nameof(GetById), new { code = form.Code }, form);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, FormeJuridique form)
        {
            try
            {
                await _formService.UpdateFormAsync(id, form); // Calls service to update 
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
                await _formService.DeleteFormAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

