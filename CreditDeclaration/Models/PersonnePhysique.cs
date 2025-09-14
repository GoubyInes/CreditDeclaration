using CreditDeclaration.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Modals
{
    [Table("Personne_Physique", Schema = "dbo")]
    public class PersonnePhysique
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("code_agence", TypeName = "nvarchar(3)")]
        public string? CodeAgence { get; set; }

        [Column("client_radical", TypeName = "nvarchar(6)")]
        public int? ClientRadical { get; set; }

        [Column("prenom", TypeName = "nvarchar(50)")]
        public string? Prenom { get; set; }

        [Column("nom", TypeName = "nvarchar(50)")]
        public string? Nom { get; set; }

        [Column("date_naissance", TypeName = "date")]
        public DateTime? DateNaissance { get; set; }

        [Column("presume", TypeName="bit")]
        public bool? Presume { get; set; } //(1=OUI / 0=NON)

        [Column("num_acte_naissance", TypeName = "decimal(5,0)") ]
        public decimal? NumActeNaissance { get; set; }

        [Column("acte_naissance", TypeName = "char(1)")]
        public string? ActeNaissance { get; set; } // (N=NORMAL, B=BIS, T=TER, Q=QUATER)

        [Column("sexe", TypeName = "char(1)")]
        public string? Sexe { get; set; }// (1=MASCULIN, 2=FEMININ)

        [Column("nationalite", TypeName = "bit")]   //notice 1 (Oui) = Algérien 0 (Non) = Étranger
        public bool? Nationalite { get; set; }



        
        [Column("pays_naissance", TypeName = "nvarchar(3)")]
        public string? PaysNaissance { get; set; }
        [ForeignKey("PaysNaissance")]
        public Pays? PaysNaissanceData { get; set; }

        
        [Column("wilaya_naissance", TypeName = "nvarchar(3)")]
        public string? WilayaNaissance { get; set; }
        [ForeignKey("WilayaNaissance")]
        public Wilaya? WilayaNaissanceData { get; set; }


        [Column("commune_naissance", TypeName = "nvarchar(3)")]
        public string? CommuneNaissance { get; set; }
        [ForeignKey(nameof(CommuneNaissance))]
        public Commune? CommuneNaissanceData { get; set; }


        [Column("prenom_pere", TypeName = "nvarchar(50)")]
        public string? PrenomPere { get; set; }

        [Column("prenom_mere", TypeName = "nvarchar(50)")]
        public string? PrenomMere { get; set; }

        [Column("nom_mere", TypeName = "nvarchar(50)")]
        public string? NomMere { get; set; }

        [Column("nom_conjoint", TypeName = "nvarchar(50)")]
        public string? NomConjoint { get; set; }

       
        [Column("etat_civil", TypeName = "nvarchar(3)")]
        public string? EtatCivil { get; set; }
        [ForeignKey("EtatCivil")]
        public EtatCivil? EtatCivilData { get; set; }


        
        [Column("profession", TypeName = "nvarchar(3)")]
        public string? Profession { get; set; }
        [ForeignKey("Profession")]
        public Profession? ProfessionData { get; set; }





        [Column("revenu", TypeName = "decimal(18,0)")]
        public decimal? Revenu { get; set; }

        [Column("adresse", TypeName = "nvarchar(100)")]
        public string? Adresse { get; set; }


       
        [Column("adresse_wilaya", TypeName = "nvarchar(3)")]
        public string? AdresseWilaya { get; set; }
        [ForeignKey("AdresseWilaya")]
        public Wilaya? AdresseWilayaData { get; set; }

        
        [Column("adresse_commune", TypeName = "nvarchar(3)")]
        public string AdresseCommune { get; set; }
        [ForeignKey("AdresseCommune")]
        public Commune? AdresseCommuneData { get; set; }


       
        [Column("type_doc", TypeName = "nvarchar(3)")]
        public string? TypeDoc { get; set; }
        [ForeignKey("TypeDoc")]
        public TypeDocument? TypeDocData { get; set; }

        [Column("num_doc", TypeName = "nvarchar(20)")]
        public string? NumDoc { get; set; }


        
        [Column("pays_emission", TypeName = "nvarchar(3)")]
        public string? PaysEmission { get; set; }
        [ForeignKey("PaysEmission")]
        public Pays? PaysEmissionData { get; set; }


       
        [Column("entite_emettrice", TypeName = "nvarchar(100)")]
        public string? EntiteEmettrice { get; set; }

        [Column("date_expiration", TypeName = "date")]
        public DateTime? DateExpiration { get; set; }

        [Column("nif", TypeName = "nvarchar(20)")]
        public string? Nif { get; set; }

        [Column("cle_intermediaire", TypeName = "nvarchar(26)")]
        public string? CleIntermediaire { get; set; }

        [Column("cle_onomastique", TypeName = "nvarchar(26)")]
        public string? CleOnomastique { get; set; }
    }
}
