using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditDeclaration.Repository
{
    public class ActiviteRepo : IActiviteRepo
    {

        private readonly AppDbContext _dbContext;

        public ActiviteRepo(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Activite>> GetAllActivities()
        {
            return await _dbContext.Activite
                                    .ToListAsync();
        }

        public async Task CreateActivity(Activite activity)
        {
            await _dbContext.AddAsync(activity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Activite> GetActivity(string code)
        {
            return await _dbContext.Activite.FindAsync(code);
        }

        public async Task UpdateActivity(Activite activity)
        {
            _dbContext.Entry(activity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteActivity(string code)
        {
            var Activity = _dbContext.Activite.Find(code);
            _dbContext.Activite.Remove(Activity!);
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
