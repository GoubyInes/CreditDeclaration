using CreditDeclaration.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Modals
{
    [Table("Entreprise_Associe", Schema = "dbo")]
    public class PersonneMoraleAssocie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int? Id { get; set; }
        [Column("code_agence", TypeName = "int")]
        public int? CodeAgence { get; set; }

        [Column("client_radicale", TypeName = "int")]
        public int? ClientRadicale { get; set; }

        [Column("num_sequentiel", TypeName = "int")]
        public int? NumSequentiel { get; set; }

        [Column("type_personne", TypeName = "int")]
        public int? TypePersonne { get; set; }

        [Column("indicateur_etat", TypeName = "char(1)")]
        public string? IndicateurEtat { get; set; }

        [Column("designation_sociale", TypeName = "varchar(100)")]
        public string? DesignationSociale { get; set; }

        [Column("sigle", TypeName = "varchar(50)")]
        public string? Sigle { get; set; }

        [Column("date_creation", TypeName = "date")]
        public DateTime? DateCreation { get; set; }

        [Column("pays_residence", TypeName = "int")]
        public int? PaysResidence { get; set; }

        [Column("identification", TypeName = "varchar(25)")]
        public string? Identification { get; set; }

        [Column("pourcentage_participation", TypeName = "decimal(18,0)")]
        public decimal? PourcentageParticipation { get; set; }

        [Column("date_pourcentage", TypeName = "date")]
        public DateTime? DatePourcentage { get; set; }

        [Column("fonction", TypeName = "int")]
        public int? Fonction { get; set; }


        [Column("entreprise_id", TypeName = "int")]
        public int? Entreprise { get; set; }
        [ForeignKey("Entreprise")]
        public PersonneMorale? EntrepriseData { get; set; }

        [Column("date_loading", TypeName = "date")]
        public DateTime? DateLoading { get; set; }
    }
}
