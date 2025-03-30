using AutoMapper;
using CursoAPi.Data.Dtos.Aluno;
using CursoAPi.Models;


namespace CursoAPi.Profiles;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<CreateAlunoDto, Aluno>();
        CreateMap<Aluno, ReadAlunoDto>();
    }
}
