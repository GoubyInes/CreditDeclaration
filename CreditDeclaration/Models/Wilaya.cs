using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Wilaya", Schema = "dbo")]
    public class Wilaya
    {
        [Key]
        [Column("code", TypeName = "nvarchar(3)")]
        public string Code { get; set; }

        [Column("domaine", TypeName = "nvarchar(100)")]
        public string? Domaine { get; set; }

        [Column("descriptif", TypeName = "nvarchar(100)")]
        public string? Descriptif { get; set; }
    }
}
