using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class ProfessionRepo : IProfessionRepo
    {

        private readonly AppDbContext _dbContext;

        public ProfessionRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Profession>> GetAllProfessions()
        {
            return await _dbContext.Profession
                                    .ToListAsync();
        }

        public async Task CreateProfession(Profession Profession)
        {
            await _dbContext.AddAsync(Profession);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Profession> GetProfession(string code)
        {
            return await _dbContext.Profession.FindAsync(code);
        }

        public async Task UpdateProfession(Profession Profession)
        {
            _dbContext.Entry(Profession).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProfession(string code)
        {
            var profession = _dbContext.Profession.Find(code);
            _dbContext.Profession.Remove(profession!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
