using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class CommuneRepo : ICommuneRepo
    {

        private readonly AppDbContext _dbContext;

        public CommuneRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Commune>> GetAllCommunes()
        {
            return await _dbContext.Commune
                                    .ToListAsync();
        }

        public async Task CreateCommune(Commune commune)
        {
            await _dbContext.AddAsync(commune);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Commune> GetCommune(string code, string domaine)
        {
            return await _dbContext.Commune.FindAsync(code, domaine);
        }

        public async Task UpdateCommune(Commune commune)
        {
            _dbContext.Entry(commune).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCommune(string code, string domaine)
        {
            var Commune = _dbContext.Commune.Find(code,domaine);
            _dbContext.Commune.Remove(Commune!);
            await _dbContext.SaveChangesAsync();
        }
    }
}
