namespace FilmeTest;

[TestFixture]
public class SalvarFilmeTest
{

    private ISalvarFilmesBO salvarFilmesBO;
    private SalvarFilmeRequestDTO request;

    [SetUp]
    public void Setup()
    {
        var serviceProvider = TestesStartup.ConfigureServices();
        salvarFilmesBO = serviceProvider.GetRequiredService<ISalvarFilmesBO>();

        request = MontaRequest();
    }

    private static SalvarFilmeRequestDTO MontaRequest()
    {
        var atores = new List<Ator>() 
        { 
            new Ator("Lucius Fox", Models.Enum.Papel.Coadjuvante),
            new Ator("Katie Holmes", Models.Enum.Papel.Protagonista),
        };

        var diretores = new List<Diretor>() 
        {
            new Diretor("Fernanda Montenegro")
        };

        var dadosFilme = new Filme("Um lar em minha vida", 160, 2019, new EstiloFilme("Ação"), atores, diretores);

        return new SalvarFilmeRequestDTO(dadosFilme);
    }

    [Test]
    public void Teste_Request_Nulo()
    {
        var response = salvarFilmesBO.SalvarFilme(null);

        Assert.That(response.CodigoStatus == System.Net.HttpStatusCode.BadRequest && response.Erro.DescricaoMensagem == "Dados não informados. Favor informá-los.");
    }

    [Test]
    public void ErroNomeNull()
    {
        request.DadosFilme.Nome = null;
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.That(response.CodigoStatus == System.Net.HttpStatusCode.BadRequest && response.Erros[0].Campo.Contains("nome"));
    }

    [Test]
    public void ErroDuracaoNull()
    {
        request.DadosFilme.Duracao = null;
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.That(response.CodigoStatus == System.Net.HttpStatusCode.BadRequest && response.Erros[0].Campo.Contains("duracao"));    }


    [Test]
    public void ErroAnoNull()
    {
        request.DadosFilme.Ano = null;
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.That(response.CodigoStatus == System.Net.HttpStatusCode.BadRequest && response.Erros[0].Campo.Contains("ano"));
    }
    
    [Test]
    public void ErroEstiloNull()
    {
        request.DadosFilme.Estilo = null;
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.That(response.CodigoStatus == System.Net.HttpStatusCode.BadRequest && response.Erros[0].Campo.Contains("estilo"));
    }
    
    [Test]
    public void ErroDescricaoEstiloNull()
    {
        request.DadosFilme.Estilo.Descricao = null;
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.That(response.CodigoStatus == System.Net.HttpStatusCode.BadRequest && response.Erros[0].Campo.Contains("estilo.descricao"));
    }
    
    [Test]
    public void ErroFilmeSemAtores()
    {
        request.DadosFilme.Atores = null;
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.That(response.CodigoStatus == System.Net.HttpStatusCode.BadRequest && response.Erros[0].Campo.Contains("atores"));
    }

    [Test]
    public void SucessoSalvarFilme()
    {
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.That(response.CodigoStatus == System.Net.HttpStatusCode.Created && response.IdFilmeCriado != 0);
    }


}