
using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class ClasseRetardRepo : IClasseRetardRepo
    {

        private readonly AppDbContext _dbContext;

        public ClasseRetardRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<ClasseRetard>> GetAllDelays()
        {
            return await _dbContext.ClasseRetard.ToListAsync();
        }

        public async Task CreateDelay(ClasseRetard Delay)
        {
            await _dbContext.AddAsync(Delay);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ClasseRetard> GetDelay(string code)
        {
            return await _dbContext.ClasseRetard.FindAsync(code);
        }

        public async Task UpdateDelay(ClasseRetard Delay)
        {
            _dbContext.Entry(Delay).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDelay(string code)
        {
            var Delay = _dbContext.ClasseRetard.Find(code);
            _dbContext.ClasseRetard.Remove(Delay!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
