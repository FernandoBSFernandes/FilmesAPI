namespace FilmeTest;

[TestFixture]
public class SalvarFilmeTest
{

    private FilmeContext filmeContext;
    private IServiceProvider serviceProvider;
    private ISalvarFilmesBO salvarFilmesBO;
    private SalvarFilmeRequestDTO request;

    [OneTimeSetUp]
    public void Setup()
    {
        serviceProvider = TestesStartup.ConfigureServices();
        filmeContext = serviceProvider.GetRequiredService<FilmeContext>();
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

        Assert.That(response.Erro != null && response.Erro.DescricaoMensagem == "Dados não informados. Favor informá-los.");
    }

    [Test]
    public void ErroNomeNull()
    {
        request.DadosFilme.Nome = null;
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.That(response.Erros.Any() && response.Erros[0].Campo.Contains("nome"));
    }

}