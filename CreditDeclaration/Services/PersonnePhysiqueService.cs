using CreditDeclaration.Interface;
using CreditDeclaration.Modals;
using CreditDeclaration.Models;
using CreditDeclaration.Repository;

namespace CreditDeclaration.Services
{
    public class PersonnePhysiqueService : IPersonnePhysiqueService
    {
        private readonly IPersonnePhysiqueRepo _personRepo;// Repository instance for database operations

        public PersonnePhysiqueService(IPersonnePhysiqueRepo personRepo)
        {
            _personRepo = personRepo; // Injecting the repository via constructor
        }

        // Retrieves all, converts them to DTOs, and returns the list
        public async Task<IEnumerable<PersonnePhysique>> GetAllPersonPhysicsAsync()
        {
            var persons = await _personRepo.GetAllPersonPhysics(); // Fetch all from repository
            // Convert each  entity into a ResponseDto and return the list
            return persons.Select(p => new PersonnePhysique
            {
                Id = p.Id,
                CodeAgence = p.CodeAgence,
                ClientRadical = p.ClientRadical,
                Prenom = p.Prenom,
                Nom = p.Nom,
                DateNaissance = p.DateNaissance,
                Presume = p.Presume,
                NumActeNaissance = p.NumActeNaissance,
                ActeNaissance = p.ActeNaissance,
                Nationalite = p.Nationalite,
                Sexe= p.Sexe,
                PaysNaissance = p.PaysNaissance,
                PaysNaissanceData = p.PaysNaissanceData,
                WilayaNaissance = p.WilayaNaissance,
                WilayaNaissanceData = p.WilayaNaissanceData,
                CommuneNaissance = p.CommuneNaissance,
                CommuneNaissanceData = p.CommuneNaissanceData,
                PrenomPere = p.PrenomPere,
                PrenomMere = p.PrenomMere,
                NomMere = p.NomMere,
                NomConjoint = p.NomConjoint,
                EtatCivil = p.EtatCivil,
                EtatCivilData = p.EtatCivilData,
                Profession = p.Profession,
                ProfessionData = p.ProfessionData,
                Revenu = p.Revenu,
                Adresse = p.Adresse,
                AdresseWilaya = p.AdresseWilaya,
                AdresseWilayaData = p.AdresseWilayaData,
                AdresseCommune = p.AdresseCommune,
                AdresseCommuneData = p.AdresseCommuneData,
                TypeDoc = p.TypeDoc,
                TypeDocData = p.TypeDocData,
                NumDoc = p.NumDoc,
                PaysEmission = p.PaysEmission,
                PaysEmissionData = p.PaysEmissionData,
                EntiteEmettrice = p.EntiteEmettrice,
                DateExpiration = p.DateExpiration,
                Nif = p.Nif,
                CleIntermediaire = p.CleIntermediaire,
                CleOnomastique = p.CleOnomastique,
            });
        }

        // Retrieves by ID and converts it to a DTO
        public async Task<PersonnePhysique> GetPersonPhysicAsync(int id)
        {
            var p = await _personRepo.GetPersonPhysic(id); // Fetch by ID

            // If the is not found, throw an exception
            if (p== null)
                throw new KeyNotFoundException("Person not found");

            // Convert entity to DTO and return it
            return new PersonnePhysique
            {
                CodeAgence = p.CodeAgence,
                ClientRadical = p.ClientRadical,
                Prenom = p.Prenom,
                Nom = p.Nom,
                DateNaissance = p.DateNaissance,
                Presume = p.Presume,
                NumActeNaissance = p.NumActeNaissance,
                ActeNaissance = p.ActeNaissance,
                Sexe = p.Sexe,
                Nationalite = p.Nationalite,
                PaysNaissance = p.PaysNaissance,
                WilayaNaissance = p.WilayaNaissance,
                CommuneNaissance = p.CommuneNaissance,
                PrenomPere = p.PrenomPere,
                PrenomMere = p.PrenomMere,
                NomMere = p.NomMere,
                NomConjoint = p.NomConjoint,
                EtatCivil = p.EtatCivil,
                Profession = p.Profession,
                Revenu = p.Revenu,
                Adresse = p.Adresse,
                AdresseWilaya = p.AdresseWilaya,
                AdresseCommune = p.AdresseCommune,
                TypeDoc = p.TypeDoc,
                NumDoc = p.NumDoc,
                PaysEmission = p.PaysEmission,
                EntiteEmettrice = p.EntiteEmettrice,
                DateExpiration = p.DateExpiration,
                Nif = p.Nif,
                CleIntermediaire = p.CleIntermediaire,
                CleOnomastique = p.CleOnomastique,
            };

        }

        // Adds a new using a request DTO
        public async Task CreatePersonPhysicAsync(PersonnePhysique p)
        {
            // Convert DTO to entity
            var person = new PersonnePhysique
            {
                CodeAgence = p.CodeAgence,
                ClientRadical = p.ClientRadical,
                Prenom = p.Prenom,
                Nom = p.Nom,
                DateNaissance = p.DateNaissance,
                Presume = p.Presume,
                NumActeNaissance = p.NumActeNaissance,
                ActeNaissance = p.ActeNaissance,
                Sexe = p.Sexe,
                Nationalite = p.Nationalite,
                PaysNaissance = p.PaysNaissance,
                WilayaNaissance = p.WilayaNaissance,
                CommuneNaissance = p.CommuneNaissance,
                PrenomPere = p.PrenomPere,
                PrenomMere = p.PrenomMere,
                NomMere = p.NomMere,
                NomConjoint = p.NomConjoint,
                EtatCivil = p.EtatCivil,
                Profession = p.Profession,
                Revenu = p.Revenu,
                Adresse = p.Adresse,
                AdresseWilaya = p.AdresseWilaya,
                AdresseCommune = p.AdresseCommune,
                TypeDoc = p.TypeDoc,
                NumDoc = p.NumDoc,
                PaysEmission = p.PaysEmission,
                EntiteEmettrice = p.EntiteEmettrice,
                DateExpiration = p.DateExpiration,
                Nif = p.Nif,
                CleIntermediaire = p.CleIntermediaire,
                CleOnomastique = p.CleOnomastique,
            };

            // Add the new  to the database
            await _personRepo.CreatePersonPhysic(person);
        }

        // Updates an existing  with new data
        public async Task UpdatePersonPhysicAsync(int id, PersonnePhysique p)
        {
            var person = await _personRepo.GetPersonPhysic(id); // Fetch the by ID

            // If the does not exist, throw an exception
            if (person == null)
                throw new KeyNotFoundException("Person not found");

            // Update fields with new values from DTO
            person.CodeAgence = p.CodeAgence;
            person.ClientRadical = p.ClientRadical;
            person.Prenom = p.Prenom;
            person.Nom = p.Nom;
            person.DateNaissance = p.DateNaissance;
            person.Presume = p.Presume;
            person.NumActeNaissance = p.NumActeNaissance;
            person.ActeNaissance = p.ActeNaissance;
            person.Sexe = p.Sexe;
            person.Nationalite = p.Nationalite;
            person.PaysNaissance = p.PaysNaissance;
            person.WilayaNaissance = p.WilayaNaissance;
            person.CommuneNaissance = p.CommuneNaissance;
            person.PrenomPere = p.PrenomPere;
            person.PrenomMere = p.PrenomMere;
            person.NomMere = p.NomMere;
            person.NomConjoint = p.NomConjoint;
            person.EtatCivil = p.EtatCivil;
            person.Profession = p.Profession;
            person.Revenu = p.Revenu;
            person.Adresse = p.Adresse;
            person.AdresseWilaya = p.AdresseWilaya;
            person.AdresseCommune = p.AdresseCommune;
            person.TypeDoc = p.TypeDoc;
            person.NumDoc = p.NumDoc;
            person.PaysEmission = p.PaysEmission;
            person.EntiteEmettrice = p.EntiteEmettrice;
            person.DateExpiration = p.DateExpiration;
            person.Nif = p.Nif;
            person.CleIntermediaire = p.CleIntermediaire;
            person.CleOnomastique = p.CleOnomastique;
            person.CleIntermediaire = p.CleIntermediaire;

            // Save the updated in the database
            await _personRepo.UpdatePersonPhysic(person);
           
        }

        // Deletes by ID
        public async Task DeletePersonPhysicAsync(int id)
        {
            var var = await _personRepo.GetPersonPhysic(id); // Fetch by ID

            // If does not exist, throw an exception
            if (var == null)
                throw new KeyNotFoundException("Person not found");

            // Delete from the database
            await _personRepo.DeletePersonPhysic(id);
        }
    }
}
