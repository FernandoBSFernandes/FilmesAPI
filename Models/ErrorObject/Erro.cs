namespace Models.ErrorObject
{
    public class Erro
    {
        public string DescricaoMensagem { get; internal set; }

        public Erro(string descricaoMensagem)
        {
            DescricaoMensagem = descricaoMensagem;
        }
    }
}
