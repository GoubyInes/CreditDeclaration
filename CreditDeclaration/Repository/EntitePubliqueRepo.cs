
using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class EntitePubliqueRepo : IEntitePubliqueRepo
    {

        private readonly AppDbContext _dbContext;

        public EntitePubliqueRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<EntitePublique>> GetAllEntities()
        {
            return await _dbContext.EntitePublique
                                    .ToListAsync();
        }

        public async Task CreateEntity(EntitePublique Entity)
        {
            await _dbContext.AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EntitePublique> GetEntity(string code)
        {
            return await _dbContext.EntitePublique.FindAsync(code);
        }

        public async Task UpdateEntity(EntitePublique Entity)
        {
            _dbContext.Entry(Entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEntity(string code)
        {
            var Entity = _dbContext.EntitePublique.Find(code);
            _dbContext.EntitePublique.Remove(Entity!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
