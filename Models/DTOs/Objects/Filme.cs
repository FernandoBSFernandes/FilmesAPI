using System.Text.Json.Serialization;

namespace Models.DTOs.Objects
{
    public class Filme
    {
        public string? Nome { get; set; }
        public int? Duracao { get; set; }
        public int? Ano { get; set; }
        [JsonPropertyName("estilo")]
        public EstiloFilme? Estilo { get; set; }
        public List<Ator>? Atores { get; set; }
        public List<Diretor>? Diretores { get; set; }

        public Filme(string? nome, int? duracao, int? ano, EstiloFilme estilo, List<Ator> atores, List<Diretor> diretores)
        {
            Nome = nome;
            Duracao = duracao;
            Ano = ano;
            Estilo = estilo;
            Atores = atores;
            Diretores = diretores;
        }
    }
}
