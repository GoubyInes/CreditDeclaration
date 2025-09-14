using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Monnaie", Schema = "dbo")]
    public class Monnaie
    {
        [Key]
        [Column("code_monnaie", TypeName = "nvarchar(10)")]
        public string Code { get; set; }

        [Column("devise", TypeName = "varchar(50)")]
        public string? Devise { get; set; }

        [Column("entite", TypeName = "varchar(50)")]
        public string? Entite { get; set; }
    }
}
