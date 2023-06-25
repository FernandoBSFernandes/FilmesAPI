using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Tables
{
    [Table("diretor")]
    public class Diretor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("idDiretor", TypeName = "bigint")]
        public long Id { get; set; }

        [Column("nome"), Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Nome { get; set; }

        [Required, Column("idFilme")]
        public List<Filme> Filmes { get; set; }
    }
}
