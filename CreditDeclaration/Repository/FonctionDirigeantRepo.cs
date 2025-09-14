using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class FonctionDirigeantRepo : IFonctionDirigeantRepo
    {

        private readonly AppDbContext _dbContext;

        public FonctionDirigeantRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<FonctionDirigeant>> GetAllFunctions()
        {
            return await _dbContext.FonctionDirigeant
                                    .ToListAsync();
        }

        public async Task CreateFunction(FonctionDirigeant Function)
        {
            await _dbContext.AddAsync(Function);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FonctionDirigeant> GetFunction(string code)
        {
            return await _dbContext.FonctionDirigeant.FindAsync(code);
        }

        public async Task UpdateFunction(FonctionDirigeant Function)
        {
            _dbContext.Entry(Function).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFunction(string code)
        {
            var function = _dbContext.FonctionDirigeant.Find(code);
            _dbContext.FonctionDirigeant.Remove(function!);
            await _dbContext.SaveChangesAsync();
        }


    }
}
