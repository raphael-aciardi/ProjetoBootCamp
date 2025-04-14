using AutoMapper;
using CursoAPi.Data.Dtos.Curso;
using CursoAPi.Models;


namespace CursoAPi.Profiles;

public class CursoProfile : Profile
{
    public CursoProfile()
    {
        CreateMap<CreateCursoDto, Curso>();
        CreateMap<Curso, ReadCursoDto>();
    }
}
