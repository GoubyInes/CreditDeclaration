
using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class DureeRepo : IDureeRepo
    {

        private readonly AppDbContext _dbContext;

        public DureeRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<DureeCredit>> GetAllDurations()
        {
            return await _dbContext.DureeCredit.ToListAsync();
        }

        public async Task CreateDuration(DureeCredit duration)
        {
            await _dbContext.AddAsync(duration);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<DureeCredit> GetDuration(string code)
        {
            return await _dbContext.DureeCredit.FindAsync(code);
        }

        public async Task UpdateDuration(DureeCredit duration)
        {
            _dbContext.Entry(duration).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDuration(string code)
        {
            var Duration = _dbContext.DureeCredit.Find(code);
            _dbContext.DureeCredit.Remove(Duration!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
