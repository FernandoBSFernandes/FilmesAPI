using Models.DTOs.Objects;

namespace Models.DTOs.Request
{
    public class SalvarFilmesEmLoteRequestDTO
    {

        public List<Filme> Filmes { get; internal set; }

        public SalvarFilmesEmLoteRequestDTO(List<Filme> filmes)
        {
            Filmes = filmes;
        }
    }
}
