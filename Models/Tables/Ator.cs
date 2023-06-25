using Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.Tables
{
    public class Ator
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("idAtor", TypeName = "bigint")]
        public long Id { get; set; }

        [Column("nome"), Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Nome { get; set; }

        [Required, Column("papel")]
        public Papel Papel { get; set; }
    }
}
