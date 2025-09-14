using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Profession", Schema = "dbo")]
    public class Profession
    {
        [Key]
        [Column("code", TypeName = "nvarchar(3)")]
        public string Code { get; set; }

        [Column("domaine", TypeName = "nvarchar(255)")]
        public string? Domaine { get; set; }

        [Column("descriptif", TypeName = "text")]
        public string? Descriptif { get; set; }
    }
}
