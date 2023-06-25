using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Tables
{
    [Table("estilo")]
    public class EstiloFilme
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("idEstilo", TypeName = "bigint")]
        public long Id { get; set; }

        [Required, Column("descricao"), MaxLength(50)]
        public string Descricao { get; set; }
    }
}
