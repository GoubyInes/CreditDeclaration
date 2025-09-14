using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class TypeGarantieRepo : ITypeGarantieRepo
    {

        private readonly AppDbContext _dbContext;

        public TypeGarantieRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<TypeGarantie>> GetAllCollaterals()
        {
            return await _dbContext.TypeGarantie
                                    .ToListAsync();
        }

        public async Task CreateCollateral(TypeGarantie Country)
        {
            await _dbContext.AddAsync(Country);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TypeGarantie> GetCollateral(string code)
        {
            return await _dbContext.TypeGarantie.FindAsync(code);
        }

        public async Task UpdateCollateral(TypeGarantie collateral)
        {
            _dbContext.Entry(collateral).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCollateral(string code)
        {
            var Collateral = _dbContext.TypeGarantie.Find(code);
            _dbContext.TypeGarantie.Remove(Collateral!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
