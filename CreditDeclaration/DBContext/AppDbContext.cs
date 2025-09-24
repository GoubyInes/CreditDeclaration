using CreditDeclaration.Modals;
using CreditDeclaration.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CreditDeclaration.DBContext
{
    public class AppDbContext : DbContext //handles database connections and is responsible for querying and saving data
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Activite> Activite { get; set; } //expose the Activity model as a DbSet
        public DbSet<Banque> Banque { get; set; }
        public DbSet<CaracteristiqueCredit> CaracteristiqueCredit { get; set; }
        public DbSet<ClasseRetard> ClasseRetard { get; set; }
        public DbSet<DureeCredit> DureeCredit { get; set; }
        public DbSet<EntitePublique> EntitePublique { get; set; }
        public DbSet<EntrepreneurIndividuel> EntrepreneurIndividuel { get; set; }
        public DbSet<EtatCivil> EtatCivil { get; set; }
        public DbSet<FonctionDirigeant> FonctionDirigeant { get; set; }
        public DbSet<FormeJuridique> FormeJuridique { get; set; }
        public DbSet<Monnaie> Monnaie { get; set; }
        public DbSet<NiveauResponsabilite> NiveauResponsabilite { get; set; }
        public DbSet<Pays> Pays { get; set; }
        public DbSet<Profession> Profession { get; set; }
        public DbSet<SourceInformationCredit> SourceInformation { get; set; }
        public DbSet<TypeDocument> TypeDocument { get; set; }
        public DbSet<TypeCredit> TypeCredit { get; set; }
        public DbSet<TypePersonne> TypePersonne { get; set; }
        public DbSet<SituationCredit> SituationCredit { get; set; }
        public DbSet<TypeGarantie> TypeGarantie { get; set; }
        public DbSet<PersonnePhysique> PersonnePhysique { get; set; }
        public DbSet<PersonneMorale> PersonneMorale { get; set; }
        public DbSet<PersonneMoraleAssocie> PersonneMoraleAssocie { get; set; }
        public DbSet<PersonneMoraleDirigeant> PersonneMoraleDirigeant { get; set; }
        public DbSet<PersonneMoraleSociete> PersonneMoraleSociete { get; set; }

        public DbSet<Wilaya> Wilaya { get; set; }
        public DbSet<Commune> Commune { get; set; }
        public DbSet<Credit> Credit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commune>()
           .HasKey(c => new { c.Code, c.Domaine });
            
            modelBuilder.Entity<PersonnePhysique>().HasOne(p => p.CommuneNaissanceData).WithMany()
                .HasForeignKey(p => new { p.CommuneNaissance, p.WilayaNaissance })
                .HasPrincipalKey(c => new { c.Code, c.Domaine });

            modelBuilder.Entity<PersonnePhysique>().HasOne(p => p.AdresseCommuneData).WithMany()
                .HasForeignKey(p => new { p.AdresseCommune, p.AdresseWilaya })
                .HasPrincipalKey(c => new { c.Code, c.Domaine });


            
            modelBuilder.Entity<EntrepreneurIndividuel>().HasOne(p => p.CommuneNaissanceData).WithMany()
                .HasForeignKey(p => new { p.CommuneNaissance, p.WilayaNaissance })
                .HasPrincipalKey(c => new{c.Code, c.Domaine });

            modelBuilder.Entity<EntrepreneurIndividuel>().HasOne(p => p.AdresseCommuneData).WithMany()
            .HasForeignKey(p => new { p.AdresseCommune, p.AdresseWilaya })
            .HasPrincipalKey(c => new {c.Code, c.Domaine});

            modelBuilder.Entity<EntrepreneurIndividuel>().HasOne(p => p.AdresseActiviteCommuneData).WithMany()
           .HasForeignKey(p => new { p.AdresseActiviteCommune, p.AdresseActiviteWilaya })
           .HasPrincipalKey(c => new { c.Code, c.Domaine });

        }

    }


}
