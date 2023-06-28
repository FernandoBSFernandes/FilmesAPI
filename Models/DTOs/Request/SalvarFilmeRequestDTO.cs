using Models.DTOs.Objects;

namespace Models.DTOs.Request
{
    public class SalvarFilmeRequestDTO
    {
        public Filme DadosFilme { get; internal set; }

        public SalvarFilmeRequestDTO(Filme dadosFilme)
        {
            DadosFilme = dadosFilme;
        }
    }
}
