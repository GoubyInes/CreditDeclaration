using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class MonnaieRepo : IMonnaieRepo
    {

        private readonly AppDbContext _dbContext;

        public MonnaieRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Monnaie>> GetAllChanges()
        {
            return await _dbContext.Monnaie
                                    .ToListAsync();
        }

        public async Task CreateChange(Monnaie Change)
        {
            await _dbContext.AddAsync(Change);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Monnaie> GetChange(string code)
        {
            return await _dbContext.Monnaie.FindAsync(code);
        }

        public async Task UpdateChange(Monnaie Change)
        {
            _dbContext.Entry(Change).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteChange(string code)
        {
            var Change = _dbContext.Monnaie.Find(code);
            _dbContext.Monnaie.Remove(Change!);
            await _dbContext.SaveChangesAsync();
        }
    }
}
