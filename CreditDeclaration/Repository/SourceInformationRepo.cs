using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class SourceInformationRepo : ISourceInformationRepo
    {

        private readonly AppDbContext _dbContext;

        public SourceInformationRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<SourceInformationCredit>> GetAllSources()
        {
            return await _dbContext.SourceInformation
                                    .ToListAsync();
        }

        public async Task CreateSource(SourceInformationCredit Source)
        {
            await _dbContext.AddAsync(Source);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SourceInformationCredit> GetSource(string code)
        {
            return await _dbContext.SourceInformation.FindAsync(code);
        }

        public async Task UpdateSource(SourceInformationCredit Source)
        {
            _dbContext.Entry(Source).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSource(string code)
        {
            var source = _dbContext.SourceInformation.Find(code);
            _dbContext.SourceInformation.Remove(source!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
