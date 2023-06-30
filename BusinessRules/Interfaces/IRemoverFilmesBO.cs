using Models.DTOs.Response;

namespace BusinessRulesContracts.Interfaces
{
    public interface IRemoverFilmesBO
    {
        RemoverFilmeDTOResponse ExcluirFilme(long id);
    }
}
