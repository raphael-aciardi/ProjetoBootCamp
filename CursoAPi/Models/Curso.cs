using System.ComponentModel.DataAnnotations;

namespace CursoAPi.Models;

public class Curso
{
    [Key]
    public int Id { get; set; }
    [Required]

    public string Nome { get; set; } = string.Empty;
    [Required]

    public string Descricao { get; set; }= string.Empty;
    [Required]

    public int CargaHoraria { get; set; }
    [Required]

    public string Nivel { get; set; } = string.Empty;
    [Required]

    public decimal Preco { get; set; }
    [Required]

    public bool Ativo { get; set; }
}
