namespace Models.DTOs.Objects
{
    public class DadosFilmeCriado
    {
        public string Nome { get; internal set; }
        public long ID { get; internal set; }

        public DadosFilmeCriado(string nome, long id)
        {
            Nome = nome;
            ID = id;
        }
    }
}
