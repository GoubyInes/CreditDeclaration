using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class TypePersonneRepo : ITypePersonneRepo
    {

        private readonly AppDbContext _dbContext;

        public TypePersonneRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<TypePersonne>> GetAllPersons()
        {
            return await _dbContext.TypePersonne
                                    .ToListAsync();
        }

        public async Task CreatePerson(TypePersonne Person)
        {
            await _dbContext.AddAsync(Person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TypePersonne> GetPerson(string code)
        {
            return await _dbContext.TypePersonne.FindAsync(code);
        }

        public async Task UpdatePerson(TypePersonne Person)
        {
            _dbContext.Entry(Person).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePerson(string code)
        {
            var person = _dbContext.TypePersonne.Find(code);
            _dbContext.TypePersonne.Remove(person!);
            await _dbContext.SaveChangesAsync();
        }

    }
}
