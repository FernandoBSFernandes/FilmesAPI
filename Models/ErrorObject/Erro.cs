namespace Models.ErrorObject
{
    public class Erro
    {
        public string Campo { get; internal set; }
        public string DescricaoMensagem { get; internal set; }



        public Erro(string descricaoMensagem)
        {
            DescricaoMensagem = descricaoMensagem;
        }

        public Erro(string campo, string descricaoMensagem) : this(descricaoMensagem)
        {
            Campo = campo;
        }
    }
}
