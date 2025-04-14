using System.ComponentModel.DataAnnotations;

 namespace CursoAPi.Data.Dtos.Curso;

public class CreateCursoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public string Nivel { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public bool Ativo { get; set; }
}
