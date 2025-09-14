using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class FormeJuridiqueRepo : IFormeJuridiqueRepo
    {

        private readonly AppDbContext _dbContext;

        public FormeJuridiqueRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<FormeJuridique>> GetAllForms()
        {
            return await _dbContext.FormeJuridique
                                    .ToListAsync();
        }

        public async Task CreateForm(FormeJuridique Form)
        {
            await _dbContext.AddAsync(Form);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FormeJuridique> GetForm(string code)
        {
            return await _dbContext.FormeJuridique.FindAsync(code);
        }

        public async Task UpdateForm(FormeJuridique Form)
        {
            _dbContext.Entry(Form).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteForm(string code)
        {
            var Form = _dbContext.FormeJuridique.Find(code);
            _dbContext.FormeJuridique.Remove(Form!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
