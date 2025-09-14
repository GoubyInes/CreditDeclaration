using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class SituationCreditRepo : ISituationCreditRepo
    {

        private readonly AppDbContext _dbContext;

        public SituationCreditRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<SituationCredit>> GetAllSituations()
        {
            return await _dbContext.SituationCredit
                                    .ToListAsync();
        }

        public async Task CreateSituation(SituationCredit Situation)
        {
            await _dbContext.AddAsync(Situation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SituationCredit> GetSituation(string code)
        {
            return await _dbContext.SituationCredit.FindAsync(code);
        }

        public async Task UpdateSituation(SituationCredit Situation)
        {
            _dbContext.Entry(Situation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSituation(string code)
        {
            var Situation = _dbContext.SituationCredit.Find(code);
            _dbContext.SituationCredit.Remove(Situation!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
