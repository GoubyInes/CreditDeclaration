using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Modals;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class EntrepreneurIndividuelRepo : IEntrepreneurIndividuelRepo
    {

        private readonly AppDbContext _dbContext;

        public EntrepreneurIndividuelRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<EntrepreneurIndividuel>> GetAllEntrepreneurs()
        {
            return await _dbContext.EntrepreneurIndividuel.Include(p => p.PaysNaissanceData).Include(p => p.WilayaNaissanceData).Include(p => p.CommuneNaissanceData)
                .Include(p => p.ProfessionData).Include(p => p.AdresseWilayaData).Include(p => p.AdresseCommuneData)
                .Include(p => p.TypeDocData).Include(p => p.PaysEmissionData)
                .Include(p => p.TypeDocData).Include(p => p.PaysEmissionData).Include(p => p.AdresseActiviteWilayaData).Include(p => p.AdresseActiviteCommuneData)
                .ToListAsync();
        }

        public async Task CreateEntrepreneur(EntrepreneurIndividuel entrepreneur)
        {
            await _dbContext.AddAsync(entrepreneur);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EntrepreneurIndividuel> GetEntrepreneur(int id)
        {
            return await _dbContext.EntrepreneurIndividuel.FindAsync(id);
        }

        public async Task UpdateEntrepreneur(EntrepreneurIndividuel entrepreneur)
        {
            _dbContext.Entry(entrepreneur).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEntrepreneur(int id)
        {
            var entrepreneur= _dbContext.EntrepreneurIndividuel.Find(id);
            _dbContext.EntrepreneurIndividuel.Remove(entrepreneur!);
            await _dbContext.SaveChangesAsync();
        }
    }
}
