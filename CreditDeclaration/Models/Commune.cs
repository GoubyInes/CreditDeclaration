
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditDeclaration.Models
{
    [Table("Commune", Schema = "dbo")]
    public class Commune
    {
        [Column("code", TypeName = "nvarchar(3)")] //, Order = 0
        public string Code { get; set; }

        [Column("domaine", TypeName = "nvarchar(3)")]
        public string Domaine { get; set; }

        [Column("descriptif", TypeName = "nvarchar(100)")]
        public string? Descriptif { get; set; }
/*
        public ICollection<PersonnePhysique> Personnes { get; set; }
        public ICollection<PersonnePhysique> PersonnesAdr { get; set; }

        public ICollection<EntrepreneurIndividuel> Entrepreneurs { get; set; }
        public ICollection<EntrepreneurIndividuel> EntrepreneursAdr { get; set; }

        public ICollection<EntrepreneurIndividuel> EntrepreneursAct { get; set; }*/
    }

}
