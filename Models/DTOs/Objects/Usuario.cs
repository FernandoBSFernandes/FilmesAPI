namespace Models.DTOs.Objects
{
    public class Usuario
    {
        public string Nome { get; internal set; }
        public string Login { get; internal set; }
        public string Senha { get; internal set; }
        public DateTime DataCadastro { get; internal set; }


        public Usuario(string login, string senha, string nome, DateTime dataCadastro)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            DataCadastro = dataCadastro;
        }
    }
}
