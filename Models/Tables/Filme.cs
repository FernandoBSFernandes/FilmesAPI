using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Tables
{
    [Table("filme")]
    public class Filme
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("idFilme", TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column("nome"), MaxLength(60), Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Column("duracao"), Range(60, 240), Required]
        public int Duracao { get; set; }

        [Column("ano"), Range(1900, 3000)]
        public int Ano { get; set; }
        
        [Column("diretor"), Required]
        public List<Diretor> Diretores { get; set; }

        [Column("estilo"), Required]
        public EstiloFilme Estilo { get; set; }
        
        [Column("ator"), Required]
        public List<Ator> Atores { get; set; }
    }
}
