using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using CreditDeclaration.Repository;
using System.Reflection.Metadata;

namespace CreditDeclaration.Services
{
    public class TypeDocumentService : ITypeDocumentService
    {
        private readonly ITypeDocumentRepo _documentRepo;// Repository instance for database operations

        public TypeDocumentService(ITypeDocumentRepo documentRepo)
        {
            _documentRepo = documentRepo; // Injecting the repository via constructor
        }

        // Retrieves all s, converts them to DTOs, and returns the list
        public async Task<IEnumerable<TypeDocument>> GetAllDocumentsAsync()
        {
            var documents = await _documentRepo.GetAllDocuments(); // Fetch all s from repository

            // Convert each  entity into a ResponseDto and return the list
            return documents.Select(a => new TypeDocument
            {
                Code = a.Code,
                Domaine = a.Domaine,
                Descriptif= a.Descriptif
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<TypeDocument> GetDocumentAsync(string code)
        {
            var var = await _documentRepo.GetDocument(code); // Fetch  by ID

            // If the  is not found, throw an exception
            if (var== null)
                throw new KeyNotFoundException("Document not found");

            // Convert entity to DTO and return it
            return new TypeDocument
            {
                Code = var.Code,
                Domaine = var.Domaine,
                Descriptif = var.Descriptif
            };

        }

        // Adds a new using a request DTO
        public async Task CreateDocumentAsync(TypeDocument Document)
        {
            // Convert DTO to entity
            var var = new TypeDocument
            {
                Code = Document.Code,
                Domaine = Document.Domaine,
                Descriptif = Document.Descriptif
            };

            // Add the new  to the database
            await _documentRepo.CreateDocument(var);
        }

        // Updates an existing  with new data
        public async Task UpdateDocumentAsync(string code, TypeDocument document)
        {
            var var = await _documentRepo.GetDocument(code); // Fetch the  by ID

            // If the  does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Document not found");

            // Update fields with new values from DTO
            if (var.Code == document.Code)
            {
                var.Domaine = document.Domaine;
                var.Descriptif = document.Descriptif;

                // Save the updated in the database
                await _documentRepo.UpdateDocument(var);
            }
            else
            {
                await CreateDocumentAsync(document);
                await DeleteDocumentAsync(code);
            }
        }

        // Deletes by ID
        public async Task DeleteDocumentAsync(string code)
        {
            var var = await _documentRepo.GetDocument(code); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Document not found");

            // Delete from the database
            await _documentRepo.DeleteDocument(code);
        }
    }
}
