using AutoMapper;

using FilmesFromDTO = Models.DTOs.Objects.Filme;
using FilmesFromDB = Models.Tables.Filme;
using DiretorFromDTO = Models.DTOs.Objects.Diretor;
using DiretorFromDB = Models.Tables.Diretor;
using AtorFromDTO = Models.DTOs.Objects.Ator;
using AtorFromDB = Models.Tables.Ator;
using EstiloFilmeFromDTO = Models.DTOs.Objects.EstiloFilme;
using EstiloFilmeFromDB = Models.Tables.EstiloFilme;

namespace APIProject.Profiles
{
    public class FilmeProfile : Profile
    {

        public FilmeProfile()
        {
            CreateMap<FilmesFromDB, FilmesFromDTO>();
            CreateMap<FilmesFromDTO, FilmesFromDB>();
            CreateMap<DiretorFromDTO, DiretorFromDB>();
            CreateMap<DiretorFromDB, DiretorFromDTO>();
            CreateMap<AtorFromDTO, AtorFromDB>();
            CreateMap<AtorFromDB, AtorFromDTO>();
            CreateMap<EstiloFilmeFromDTO, EstiloFilmeFromDB>();
            CreateMap<EstiloFilmeFromDB, EstiloFilmeFromDTO>();
        }

    }
}
