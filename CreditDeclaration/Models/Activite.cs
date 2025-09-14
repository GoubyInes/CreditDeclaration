using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Activite", Schema = "dbo")]
    public class Activite
    {
        [Key]
        [Column("code", TypeName = "nvarchar(2)")]
        public string Code { get; set; }

        [Column("domaine", TypeName = "nvarchar(150)")]
        public string? Domaine { get; set; }

        [Column("descriptif", TypeName = "nvarchar(150)")]
        public string? Descriptif { get; set; }
    }
}
