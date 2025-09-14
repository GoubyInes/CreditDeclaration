using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Modals
{
    [Table("Personne_Morale_Dirigeant", Schema = "dbo")]
    public class PersonneMoraleDirigeant
    {
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
    }
}
