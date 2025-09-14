using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Banque", Schema = "dbo")]
    public class Banque
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
