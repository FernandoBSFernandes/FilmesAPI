namespace Models.DTOs.Objects
{
    public class Diretor
    {
        public string Nome { get; internal set; }

        public Diretor(string nome)
        {
            Nome = nome;
        }
    }
}
