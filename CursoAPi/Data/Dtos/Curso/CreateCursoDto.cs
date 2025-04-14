using System.ComponentModel.DataAnnotations;

 namespace CursoAPi.Data.Dtos.Curso;

public class CreateCursoDto
{
    [Key]
    public int Id { get; set; }
    [Required]

    public string Nome { get; set; } = string.Empty;
    [Required]

    public string Descricao { get; set; } = string.Empty;
    [Required]

    public int CargaHoraria { get; set; }
    [Required]

    public string Nivel { get; set; } = string.Empty;
    [Required]
    public decimal Preco { get; set; }
    [Required]
    public bool Ativo { get; set; }
}
