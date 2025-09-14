using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class PersonneMoraleRepo : IPersonneMoraleRepo
    {

        private readonly AppDbContext _dbContext;

        public PersonneMoraleRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<PersonneMorale>> GetAllPersonMorals()
        {
            return await _dbContext.PersonneMorale
                                    .ToListAsync();
        }

        public async Task CreatePersonMoral(PersonneMorale PersonneMorale)
        {
            await _dbContext.AddAsync(PersonneMorale);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PersonneMorale> GetPersonMoral(int id)
        {
            return await _dbContext.PersonneMorale.FindAsync(id);
        }

        public async Task UpdatePersonMoral(PersonneMorale PersonneMorale)
        {
            _dbContext.Entry(PersonneMorale).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePersonMoral(int id)
        {
            var PersonneMorale = _dbContext.PersonneMorale.Find(id);
            _dbContext.PersonneMorale.Remove(PersonneMorale!);
            await _dbContext.SaveChangesAsync();
        }


        /*private readonly List<Activite> _activities = new();

         public async Task<IEnumerable<Activite>> GetAllActivities()
         {
             return _activities.Select(a => new Activite
             {
                 Code= a.Code,
                 Domaine = a.Domaine,
                 Descriptif = a.Descriptif
             }).ToList();
         }

         public async Task<Activite> GetActivity(string code)
         {
             var Activity = _activities.FirstOrDefault(a => a.Code == code);
             if (Activity == null) return null;

             return new Activite();

         }

         public async Task<Activite> CreateActivity(Activite activity)
         {
             var activite = new Activite
             {
                 Code = activity.Code,
                 Domaine = activity.Domaine,
                 Descriptif = activity.Descriptif
             };

             _activities.Add(activite);

             return activite;
         }

         public async Task UpdateActivity(Activite activity)
         {
             var activite = _activities.FirstOrDefault(a => a.Code == activity.Code);
             if (activite == null) return;

             activity.Domaine = activity.Domaine;
             activity.Descriptif = activity.Descriptif;
         }

         public async Task DeleteActivity(string code)
         {
             var activite = _activities.FirstOrDefault(a => a.Code == code);
             if (activite != null) _activities.Remove(activite);
         }*/
    }
}
