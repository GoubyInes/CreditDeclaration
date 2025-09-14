using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Fonction_Dirigeant", Schema = "dbo")]
    public class FonctionDirigeant
    {
        [Key]
        [Column("code", TypeName = "nvarchar(10)")]
        public string Code { get; set; }

        [Column("domaine", TypeName = "nvarchar(100)")]
        public string? Domaine { get; set; }

        [Column("descriptif", TypeName = "nvarchar")]
        public string? Descriptif { get; set; }
    }
}
