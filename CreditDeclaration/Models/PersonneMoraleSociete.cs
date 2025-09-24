using CreditDeclaration.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Modals
{
    [Table("Entreprise_Societe", Schema = "dbo")]
    public class PersonneMoraleSociete
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

        [Column("nif", TypeName = "varchar(20)")]
        public string? Nif { get; set; }

        [Column("pourcentage_participation", TypeName = "decimal(18,0)")]
        public decimal? PourcentageParticipation { get; set; }

        [Column("date_pourcentage", TypeName = "date")]
        public DateTime? DatePourcentage { get; set; }

        [Column("designation_social", TypeName = "varchar(100)")]
        public string? DesignationSocial { get; set; }

        [Column("code_activite", TypeName = "int")]
        public int? CodeActivite { get; set; }

        [Column("forme_juridique", TypeName = "int")]
        public int? FormeJuridique { get; set; }

        [Column("entreprise_id", TypeName = "int")]
        public int? Entreprise { get; set; }
        [ForeignKey("Entreprise")]
        public PersonneMorale? EntrepriseData { get; set; }

        [Column("date_loading", TypeName = "date")]
        public DateTime? DateLoading { get; set; }
    }
}
