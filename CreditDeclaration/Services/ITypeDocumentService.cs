using CreditDeclaration.Models;

namespace CreditDeclaration.Services
{
    public interface ITypeDocumentService
    {
        Task<IEnumerable<TypeDocument>> GetAllDocumentsAsync();
        Task CreateDocumentAsync(TypeDocument document);
        Task<TypeDocument> GetDocumentAsync(string code);
        Task UpdateDocumentAsync(string code, TypeDocument document);
        Task DeleteDocumentAsync(string code);
    }
}
