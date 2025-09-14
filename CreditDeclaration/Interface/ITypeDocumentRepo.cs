using CreditDeclaration.Models;

namespace CreditDeclaration.Interface
{
    public interface ITypeDocumentRepo
    {
        Task<IEnumerable<TypeDocument>> GetAllDocuments();
        Task CreateDocument(TypeDocument document);
        Task<TypeDocument> GetDocument(string code);
        Task UpdateDocument(TypeDocument document);
        Task DeleteDocument(string code);
    }
}
