namespace CursoAPi.Data.Dtos.Curso;

public class ReadCursoDto
{
    public string Nome { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public string Nivel { get; set; } = string.Empty;
}
