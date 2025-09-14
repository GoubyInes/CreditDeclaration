using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class PaysRepo : IPaysRepo
    {

        private readonly AppDbContext _dbContext;

        public PaysRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Pays>> GetAllCountries()
        {
            return await _dbContext.Pays
                                    .ToListAsync();
        }

        public async Task CreateCountry(Pays Country)
        {
            await _dbContext.AddAsync(Country);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Pays> GetCountry(string code)
        {
            return await _dbContext.Pays.FindAsync(code);
        }

        public async Task UpdateCountry(Pays Country)
        {
            _dbContext.Entry(Country).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCountry(string code)
        {
            var country = _dbContext.Pays.Find(code);
            _dbContext.Pays.Remove(country!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
