namespace Models.DTOs.Objects
{
    public class EstiloFilme
    {
        public string Descricao { get; internal set; }

        public EstiloFilme(string descricao)
        {
            Descricao = descricao;
        }
    }
}