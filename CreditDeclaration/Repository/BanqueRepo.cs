
using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class BanqueRepo : IBanqueRepo
    {

        private readonly AppDbContext _dbContext;

        public BanqueRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Banque>> GetAllBanks()
        {
            return await _dbContext.Banque
                                    .ToListAsync();
        }

        public async Task CreateBank(Banque bank)
        {
            await _dbContext.AddAsync(bank);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Banque> GetBank(string code)
        {
            return await _dbContext.Banque.FindAsync(code);
        }

        public async Task UpdateBank(Banque bank)
        {
            _dbContext.Entry(bank).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBank(string code)
        {
            var Bank = _dbContext.Banque.Find(code);
            _dbContext.Banque.Remove(Bank!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
