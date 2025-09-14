using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class TypeCreditRepo : ITypeCreditRepo
    {

        private readonly AppDbContext _dbContext;

        public TypeCreditRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<TypeCredit>> GetAllTypes()
        {
            return await _dbContext.TypeCredit
                                    .ToListAsync();
        }

        public async Task CreateType(TypeCredit type)
        {
            await _dbContext.AddAsync(type);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TypeCredit> GetType(string code)
        {
            return await _dbContext.TypeCredit.FindAsync(code);
        }

        public async Task UpdateType(TypeCredit Type)
        {
            _dbContext.Entry(Type).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteType(string code)
        {
            var type = _dbContext.TypeCredit.Find(code);
            _dbContext.TypeCredit.Remove(type!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
