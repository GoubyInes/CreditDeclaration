using CreditDeclaration.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Modals
{
    [Table("Credit", Schema = "dbo")]
    public Credit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }
        
        [Column("date_notation", TypeName = "date")]
        public DateTime? DateNotation { get; set; }

        [Column("date_declaration", TypeName = "date")]
        public DateTime? DateDeclaration { get; set; }

         
        [Column("niveau_responsabilite", TypeName = "nvarchar(3)")]
        public string? NiveauResponsabilite { get; set; }
        [ForeignKey("NiveauResponsabilite")]
        public NiveauResponsabilite? NiveauResponsabiliteData { get; set; }

        [Column("identifiant_plafond", TypeName = "nvarchar(3)")]
        public string? IdentifiantPlafond { get; set; }

        [Column("numero_contrat", TypeName = "nvarchar(3)")]
        public string? NumeroContrat { get; set; }

        [Column("monnaie", TypeName = "nvarchar(3)")]
        public string? Monnaie { get; set; }
        [ForeignKey("Monnaie")]
        public Monnaie? Monnaie { get; set; }

        [Column("num_identite_bancaire", TypeName = "nvarchar(50)")]
        public string? NumeroIdentiteBancaire { get; set; }

        [Column("pays_agence", TypeName = "nvarchar(3)")]
        public string? PaysAgence { get; set; }
        [ForeignKey("PaysAgence")]
        public Pays? PaysAgenceData { get; set; }

        [Column("code_agence", TypeName = "nvarchar(3)")]
        public string? CodeAgence { get; set; }

        [Column("wilaya_agence", TypeName = "nvarchar(3)")]
        public string? WilayaAgence { get; set; }
        [ForeignKey("WilayaAgence")]
        public Wilaya? WilayaAgenceData { get; set; }

        [Column("activite", TypeName = "nvarchar(3)")]
        public string? Activite { get; set; }
        [ForeignKey("Activite")]
        public Activite? ActiviteData { get; set; }

        [Column("type_credit", TypeName = "nvarchar(3)")]
        public string? TypeCredit { get; set; }
        [ForeignKey("TypeCredit")]
        public TypeCredit? TypeCreditData { get; set; }

        [Column("situation", TypeName = "nvarchar(3)")]
        public string? Situation { get; set; }
        [ForeignKey("Situation")]
        public SituationCredit? SituationData { get; set; }

        [Column("classe_retard", TypeName = "nvarchar(3)")]
        public string? ClasseRetard { get; set; }
        [ForeignKey("ClasseRetard")]
        public ClasseRetard? ClasseRetardData { get; set; }
      
        [Column("duree_initiale", TypeName = "nvarchar(3)")]
        public string? DureeInitiale { get; set; }
        [ForeignKey("DureeInitiale")]
        public DureeCredit? DureeInitialeData { get; set; }

        [Column("duree_restante", TypeName = "nvarchar(3)")]
        public string? DureeRestante { get; set; }
        [ForeignKey("DureeRestante")]
        public DureeCredit? DureeRestanteData { get; set; }

        [Column(accorde"", TypeName = "decimal(18,0)")]
        public decimal? CreditAccorde { get; set; }

        [Column("encours", TypeName = "decimal(18,0)")]
        public decimal? Encours { get; set; }

        [Column("cout_total", TypeName = "decimal(18,0)")]
        public decimal? CoutTotal { get; set; }

        [Column("montant_mensualite", TypeName = "decimal(18,0)")]
        public decimal? MontantMensualite { get; set; }

        [Column("taux_interet", TypeName = "decimal(8,5)")]
        public decimal? TauxInteret { get; set; }
        
        [Column("date_impaye", TypeName = "date")]
        public DateTime? DateConstatationImpayes { get; set; }

        [Column("nb_echeance_impayee", TypeName = "decimal(18,0)")]
        public decimal? NombreEcheancesImpayees { get; set; }

        [Column("interet_courus", TypeName = "decimal(18,0)")]
        public decimal? InteretsCourus { get; set; }

        [Column("montant_capital_nrecouvre", TypeName = "decimal(18,0)")]
        public decimal? MontantCapitalNonRecouvre { get; set; }

        [Column("montant_interet_nrecouvre", TypeName = "decimal(18,0)")]
        public decimal? MontantInteretsNonRecouvre { get; set; }

        [Column("date_rejet", TypeName = "date")]
        public DateTime? DateRejet { get; set; }
        
        [Column("date_octroi", TypeName = "date")]
        public DateTime? DateOctroi { get; set; }
        
        [Column("date_expiration", TypeName = "date")]
        public DateTime? DateExpiration { get; set; }

        [Column("code_notation", TypeName = "nvarchar(5)")]
        public string Notation { get; set; }

        [Column("organisme_notation", TypeName = "nvarchar(3)")]
        public string OrganismeNotation { get; set; }

        [Column("date_notation", TypeName = "date")]
        public DateTime? DateNotation { get; set; }  

        [Column("operation", TypeName = "nvarchar(3)")]
        public string CaracteristiqueOperation { get; set; }

        [Column("descriptif_operation", TypeName = "nvarchar(3)")]
        public string DescriptifOperation { get; set; }

        [Column("type_garantie", TypeName = "nvarchar(3)")]
        public string? TypeGarantie { get; set; }
        [ForeignKey("TypeGarantie")]
        public TypeGarantie? TypeGarantieData { get; set; }
        
        [Column("montant_garantie", TypeName = "decimal(18,0)")]
        public decimal? MontantGarantie { get; set; }

        [Column("date_loading", TypeName = "date")]
        public DateTime? DateLoading { get; set; }
    }
}
