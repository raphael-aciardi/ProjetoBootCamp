namespace CursoAPi.Validations;

using CursoAPi.Data.Dtos.Aluno;
using CursoAPi.Models;
using FluentValidation;

public class AlunoValidator : AbstractValidator<CreateAlunoDto>
{
    public AlunoValidator()
    {
        RuleFor(a => a.NomeCompleto)
            .NotEmpty().WithMessage("O seu nome é obrigatório")
            .MaximumLength(100)
            .WithMessage("O seu nome deve ter no máximo 100 caracteres")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$")
            .WithMessage("O nome deve conter apenas letras e espaços.");

        RuleFor(a => a.Email).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O seu email é obrigatório")
            .EmailAddress().WithMessage("O seu email é inválido")
            .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Apenas e-mails do Gmail são permitidos.");

    }
}
