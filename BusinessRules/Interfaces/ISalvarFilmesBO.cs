﻿using Models.DTOs.Request;
using Models.DTOs.Response;

namespace BusinessRulesContracts.Interfaces
{
    public interface ISalvarFilmesBO
    {
        SalvarFilmeResponseDTO SalvarFilme(SalvarFilmeRequestDTO request);
        //SalvarFilmeRequestDTO SalvarFilmes();
    }
}