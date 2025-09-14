using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class TypeDocumentController : ControllerBase
    {
        private readonly ITypeDocumentService _documentService; // Service instance for business logic

        public TypeDocumentController(ITypeDocumentService documentService)
        {
            _documentService = documentService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _documentService.GetAllDocumentsAsync(); // Calls service to get all 
            return Ok(documents); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var document = await _documentService.GetDocumentAsync(code); // Calls service to fetcht by ID
                return Ok(document); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(TypeDocument document)
        {
            await _documentService.CreateDocumentAsync(document); // Calls service to add a new 
            return Ok(document); //CreatedAtAction(nameof(GetById), new { code = bank.Code }, bank);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, TypeDocument document)
        {
            try
            {
                await _documentService.UpdateDocumentAsync(id, document); // Calls service to update 
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
                await _documentService.DeleteDocumentAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

