using Models.DTOs.Request;
using Models.DTOs.Response;

namespace BusinessRulesContracts.Interfaces
{
    public interface IAtualizarFilmeBO
    {
        AtualizarFilmeResponseDTO AtualizarFilme(AtualizarFilmeRequestDTO request, long id);
        //AtualizarFilmeResponseDTO AtualizarFilmes(AtualizarFilmeRequestDTO request);
    }
}
