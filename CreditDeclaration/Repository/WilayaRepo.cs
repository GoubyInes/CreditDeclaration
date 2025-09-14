using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class WilayaRepo : IWilayaRepo
    {

        private readonly AppDbContext _dbContext;

        public WilayaRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Wilaya>> GetAllWilayas()
        {
            return await _dbContext.Wilaya
                                    .ToListAsync();
        }

        public async Task CreateWilaya(Wilaya wilaya)
        {
            await _dbContext.AddAsync(wilaya);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Wilaya> GetWilaya(string code)
        {
            return await _dbContext.Wilaya.FindAsync(code);
        }

        public async Task UpdateWilaya(Wilaya wilaya)
        {
            _dbContext.Entry(wilaya).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteWilaya(string code)
        {
            var Wilaya = _dbContext.Wilaya.Find(code);
            _dbContext.Wilaya.Remove(Wilaya!);
            await _dbContext.SaveChangesAsync();
        }


    }
}
