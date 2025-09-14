using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class TypeDocumentRepo : ITypeDocumentRepo
    {

        private readonly AppDbContext _dbContext;

        public TypeDocumentRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<TypeDocument>> GetAllDocuments()
        {
            return await _dbContext.TypeDocument
                                    .ToListAsync();
        }

        public async Task CreateDocument(TypeDocument document)
        {
            await _dbContext.AddAsync(document);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TypeDocument> GetDocument(string code)
        {
            return await _dbContext.TypeDocument.FindAsync(code);
        }

        public async Task UpdateDocument(TypeDocument document)
        {
            _dbContext.Entry(document).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDocument(string code)
        {
            var document = _dbContext.TypeDocument.Find(code);
            _dbContext.TypeDocument.Remove(document!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
