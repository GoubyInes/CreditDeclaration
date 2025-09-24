using CreditDeclaration.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Modals
{
    [Table("Entreprise_Dirigeant", Schema = "dbo")]
    public class PersonneMoraleDirigeant
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

        [Column("identification", TypeName = "varchar(36)")]
        public string? Identification { get; set; }

        [Column("nom", TypeName = "varchar(50)")]
        public string? Nom { get; set; }

        [Column("prenom", TypeName = "varchar(50)")]
        public string? Prenom { get; set; }

        [Column("fonction", TypeName = "int")]
        public int? Fonction { get; set; }

        [Column("pays_residence", TypeName = "int")]
        public int? PaysResidence { get; set; }

        [Column("Nationalite", TypeName = "int")]
        public int? Nationalite { get; set; }

        [Column("entreprise_id", TypeName = "int")]
        public int? Entreprise { get; set; }
        [ForeignKey("Entreprise")]
        public PersonneMorale? EntrepriseData { get; set; }

        [Column("date_loading", TypeName = "date")]
        public DateTime? DateLoading { get; set; }
    }
}
