using Microsoft.AspNetCore.JsonPatch;
using Models.DTOs.Request;
using Models.DTOs.Response;

namespace BusinessRulesContracts.Interfaces
{
    public interface IAtualizarFilmeBO
    {
        AtualizarFilmeResponseDTO AtualizarFilme(AtualizarFilmeRequestDTO request, long id);
        AtualizarFilmeResponseDTO AtualizarInfoFilme(long id, JsonPatchDocument jsonRequest);
    }
}
