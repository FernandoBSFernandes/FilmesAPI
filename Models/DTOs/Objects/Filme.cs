using System.Text.Json.Serialization;

namespace Models.DTOs.Objects
{
    public class Filme
    {
        public string Nome { get; set; }
        public int? Duracao { get; set; }
        public int? Ano { get; set; }
        [JsonPropertyName("estilo")]
        public EstiloFilme Estilo { get; set; }
        public List<Ator> Atores { get; set; }
        public List<Diretor> Diretores { get; set; }

    }
}
