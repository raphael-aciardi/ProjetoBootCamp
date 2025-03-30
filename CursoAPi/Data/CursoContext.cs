using CursoAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoAPi.Data;

public class CursoContext(DbContextOptions<CursoContext> opts) : DbContext(opts)
{
    public DbSet<Aluno> Alunos { get; set; }
}
