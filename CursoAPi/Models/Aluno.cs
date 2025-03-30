using System.ComponentModel.DataAnnotations;

namespace CursoAPi.Models;

public class Aluno
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string NomeCompleto { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Telefone { get; set; } = string.Empty;

    [Required]
    public string Endereco { get; set; } = string.Empty;
    [Required]
    public string Cidade { get; set; } = string.Empty;
    [Required]
    public string Estado { get; set; } = string.Empty;
}
