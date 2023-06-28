namespace Models.DTOs.Objects
{
    public class Filme
    {

        public string Nome { get; set; }
        public List<Diretor> Diretores { get; set; }
        public decimal Duracao { get; set; }
        public EstiloFilme Estilo { get; set; }
        public List<Ator> Atores { get; set; }

    }
}
