using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Niveau_Responsabilite", Schema = "dbo")]
    public class NiveauResponsabilite
    {
        [Key]
        [Column("code", TypeName = "nvarchar(3)")]
        public string Code { get; set; }

        [Column("domaine", TypeName = "nvarchar(50)")]
        public string? Domaine { get; set; }

        [Column("descriptif", TypeName = "nvarchar(100)")]
        public string? Descriptif { get; set; }
    }
}
