using Models.DTOs.Response;

namespace BusinessRulesContracts.Interfaces
{
    public interface IRetornaFilmesBO
    {
        RetornaTodosFilmesResponseDTO RetornaTodosFilmes();
        RetornaFilmeResponseDTO RetornaFilmePorId(long id);
    }
}
