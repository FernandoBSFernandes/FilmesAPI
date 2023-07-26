namespace FilmeTest;

[TestFixture]
public class SalvarFilmeTest
{

    private FilmeContext filmeContext;
    private IServiceProvider serviceProvider;
    private ISalvarFilmesBO salvarFilmesBO;

    [OneTimeSetUp]
    public void Setup()
    {
        serviceProvider = TestesStartup.ConfigureServices();
        filmeContext = serviceProvider.GetRequiredService<FilmeContext>();
        salvarFilmesBO = serviceProvider.GetRequiredService<ISalvarFilmesBO>();
    }

    [Test]
    public void ErroDadosNulos()
    {
        var request = new SalvarFilmeRequestDTO(null);
        var response = salvarFilmesBO.SalvarFilme(request);

        Assert.IsTrue(response.Erro != null && response.Erro.DescricaoMensagem == "Dados não informados. Favor informá-los.");
    }
}