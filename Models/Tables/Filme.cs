using Models.DTOs.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tables
{
    [Table("filme")]
    public class Filme
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("idFilme", TypeName = "bigint")]
        public long Id { get; set; }
        []
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public decimal Duracao { get; set; }
        public EstiloFilme Estilo { get; set; }
        public List<Ator> Atores { get; set; }
    }
}
