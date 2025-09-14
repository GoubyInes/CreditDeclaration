using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Modals;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class PersonnePhysiqueRepo : IPersonnePhysiqueRepo
    {

        private readonly AppDbContext _dbContext;

        public PersonnePhysiqueRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<PersonnePhysique>> GetAllPersonPhysics()
        {
            return await _dbContext.PersonnePhysique.Include(p => p.PaysNaissanceData).Include(p => p.WilayaNaissanceData).Include(p => p.CommuneNaissanceData)
                .Include(p => p.ProfessionData).Include(p => p.AdresseWilayaData).Include(p => p.AdresseCommuneData)
                .Include(p => p.TypeDocData).Include(p => p.PaysEmissionData)
                .ToListAsync();
        }

        public async Task CreatePersonPhysic(PersonnePhysique PersonnePhysique)
        {
            await _dbContext.AddAsync(PersonnePhysique);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PersonnePhysique> GetPersonPhysic(int id)
        {
            return await _dbContext.PersonnePhysique.FindAsync(id);
        }

        public async Task UpdatePersonPhysic(PersonnePhysique PersonnePhysique)
        {
            _dbContext.Entry(PersonnePhysique).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePersonPhysic(int id)
        {
            var PersonnePhysique = _dbContext.PersonnePhysique.Find(id);
            _dbContext.PersonnePhysique.Remove(PersonnePhysique!);
            await _dbContext.SaveChangesAsync();
        }
    }
}
