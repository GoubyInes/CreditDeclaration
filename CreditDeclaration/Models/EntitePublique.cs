using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Entite_Publique", Schema = "dbo")]
    public class EntitePublique
    {
        [Key]
        [Column("code", TypeName = "nvarchar(3)")]
        public string Code { get; set; }

        [Column("domaine", TypeName = "nvarchar(150)")]
        public string? Domaine { get; set; }

        [Column("descriptif", TypeName = "nvarchar")]
        public string? Descriptif { get; set; }
    }
}
