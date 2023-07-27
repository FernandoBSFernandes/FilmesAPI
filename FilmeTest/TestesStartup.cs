using FilmeTest.Profiles;

namespace FilmeTest
{
    public static class TestesStartup
    {

        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            var options = new DbContextOptionsBuilder<FilmeContext>()
            .UseInMemoryDatabase(databaseName: "MyTestDatabase")
            .Options;

            var context = new FilmeContext(options);
            services.AddSingleton(context);

            //Adding AutoMapper
            services.AddAutoMapper(typeof(FilmeProfile));

            services.AddTransient<ISalvarFilmesBO, SalvarFilmesBO>();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

    }
}
