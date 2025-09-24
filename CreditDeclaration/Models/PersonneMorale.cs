using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Entreprise", Schema = "dbo")]
    public class PersonneMorale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int? Id { get; set; }

        [Column("code_agence", TypeName = "int")]
        public int? CodeAgence { get; set; }

        [Column("client_radicale", TypeName = "int")]
        public int? ClientRadicale { get; set; }

        [Column("date_creation", TypeName = "date")]
        public DateTime? DateCreation { get; set; }

        [Column("sigle", TypeName = "varchar(20)")]
        public string? Sigle { get; set; }

        [Column("adresse_activite", TypeName = "varchar(100)")]
        public string? AdresseActivite { get; set; }

        [Column("wilaya_activite", TypeName = "int")]
        public int? WilayaActivite { get; set; }

        [Column("commune_activite", TypeName = "int")]
        public int? CommuneActivite { get; set; }

        [Column("adresse_siege", TypeName = "varchar(100)")]
        public string? AdresseSiege { get; set; }

        [Column("wilaya_siege", TypeName = "int")]
        public int? WilayaSiege { get; set; }

        [Column("commune_siege", TypeName = "int")]
        public int? CommuneSiege { get; set; }

        [Column("forme_juridique", TypeName = "int")]
        public int? FormeJuridique { get; set; }

        [Column("code_activite_principale", TypeName = "int")]
        public int? CodeActivitePrincipale { get; set; }

        [Column("entite_publique", TypeName = "int")]
        public int? EntitePublique { get; set; }

        [Column("effectif", TypeName = "decimal(18,0)")]
        public decimal? Effectif { get; set; }

        [Column("valeur_ajoute", TypeName = "decimal(18,0)")]
        public decimal? ValeurAjoute { get; set; }

        [Column("chiffre_affaire", TypeName = "decimal(18,0)")]
        public decimal? ChiffreAffaire { get; set; }

        [Column("resultat_net", TypeName = "decimal(18,0)")]
        public decimal? ResultatNet { get; set; }

        [Column("total_bilan", TypeName = "decimal(18,0)")]
        public decimal? TotalBilan { get; set; }

        [Column("total_actif", TypeName = "decimal(18,0)")]
        public decimal? TotalActif { get; set; }

        [Column("capital_emis", TypeName = "decimal(18,0)")]
        public decimal? CapitalEmis { get; set; }

        [Column("reserve", TypeName = "decimal(18,0)")]
        public decimal? Reserve { get; set; }

        [Column("raport_nouveau", TypeName = "decimal(18,0)")]
        public decimal? RaportNouveau { get; set; }

        [Column("capitaux", TypeName = "decimal(18,0)")]
        public decimal? Capitaux { get; set; }

        [Column("emprunt", TypeName = "decimal(18,0)")]
        public decimal? Emprunt { get; set; }

        [Column("excedent_brut", TypeName = "decimal(18,0)")]
        public decimal? ExcedentBrut { get; set; }

        [Column("resultat_financier", TypeName = "decimal(18,0)")]
        public decimal? ResultatFinancier { get; set; }

        [Column("date_bilan", TypeName = "decimal(18,0)")]
        public decimal? DateBilan { get; set; }

        [Column("type_doc", TypeName = "int")]
        public int? TypeDoc { get; set; }

        [Column("num_doc", TypeName = "varchar(20)")]
        public string? NumDoc { get; set; }

        [Column("pays_emission", TypeName = "int")]
        public int? PaysEmission { get; set; }

        [Column("enite_emettrice", TypeName = "varchar(20)")]
        public string? EniteEmettrice { get; set; }

        [Column("date_expiration", TypeName = "date")]
        public DateTime? DateExpiration { get; set; }

        [Column("nif", TypeName = "varchar(20)")]
        public string? Nif { get; set; }

        [Column("cle_intermediaire", TypeName = "varchar(26)")]
        public string? CleIntermediaire { get; set; }

        [Column("cle_onomastique", TypeName = "varchar(26)")]
        public string? CleOnomastique { get; set; }

        [Column("date_loading", TypeName = "date")]
        public DateTime? DateLoading { get; set; }
    }
}
