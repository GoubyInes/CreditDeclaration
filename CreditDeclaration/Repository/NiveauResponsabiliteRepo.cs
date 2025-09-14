
using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class NiveauResponsabiliteRepo : INiveauResponsabiliteRepo
    {

        private readonly AppDbContext _dbContext;

        public NiveauResponsabiliteRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<NiveauResponsabilite>> GetAllLevels()
        {
            return await _dbContext.NiveauResponsabilite
                                    .ToListAsync();
        }

        public async Task CreateLevel(NiveauResponsabilite Level)
        {
            await _dbContext.AddAsync(Level);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<NiveauResponsabilite> GetLevel(string code)
        {
            return await _dbContext.NiveauResponsabilite.FindAsync(code);
        }

        public async Task UpdateLevel(NiveauResponsabilite Level)
        {
            _dbContext.Entry(Level).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLevel(string code)
        {
            var Level = _dbContext.NiveauResponsabilite.Find(code);
            _dbContext.NiveauResponsabilite.Remove(Level!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
