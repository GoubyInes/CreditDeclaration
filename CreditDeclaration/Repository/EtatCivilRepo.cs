
using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class EtatCivilRepo : IEtatCivilRepo
    {

        private readonly AppDbContext _dbContext;

        public EtatCivilRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<EtatCivil>> GetAllStatus()
        {
            return await _dbContext.EtatCivil
                                    .ToListAsync();
        }

        public async Task CreateStatus(EtatCivil status)
        {
            await _dbContext.AddAsync(status);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EtatCivil> GetStatus(string code)
        {
            return await _dbContext.EtatCivil.FindAsync(code);
        }

        public async Task UpdateStatus(EtatCivil Status)
        {
            _dbContext.Entry(Status).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStatus(string code)
        {
            var Status = _dbContext.EtatCivil.Find(code);
            _dbContext.EtatCivil.Remove(Status!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
