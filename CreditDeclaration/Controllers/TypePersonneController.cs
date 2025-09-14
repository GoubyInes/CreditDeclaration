using CreditDeclaration.Models;
using CreditDeclaration.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CreditDeclaration.Controllers
{
    [ApiController] // Specifies that this is an API controller
    [Route("api/[controller]")] // Defines the route as 'api/'
    public class TypePersonneController : ControllerBase
    {
        private readonly ITypePersonneService _personService; // Service instance for business logic

        public TypePersonneController(ITypePersonneService personService)
        {
            _personService = personService; // Injecting the service via constructor
        }

        // Handles HTTP GET request to fetch all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllPersonsAsync(); // Calls service to get all 
            return Ok(persons); // Returns 200 OK response with data
        }

        // Handles HTTP GET request to fetch a single by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string code)
        {
            try
            {
                var person = await _personService.GetPersonAsync(code); // Calls service to fetcht by ID
                return Ok(person); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }

        // Handles HTTP POST request to add a new 
        [HttpPost]
        public async Task<IActionResult> Add(TypePersonne person)
        {
            await _personService.CreatePersonAsync(person); // Calls service to add a new 
            return Ok(person); //CreatedAtAction(nameof(GetById), new { code = bank.Code }, bank);
            // Returns 201 Created response with location header pointing to the new
        }

        // Handles HTTP PUT request to update an existing 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, TypePersonne bank)
        {
            try
            {
                await _personService.UpdatePersonAsync(id, bank); // Calls service to update 
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
                await _personService.DeletePersonAsync(id); // Calls service to delete 
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if does not exist
            }
        }
    }
}

