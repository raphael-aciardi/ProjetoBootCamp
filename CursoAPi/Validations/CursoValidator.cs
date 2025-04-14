using CursoAPi.Data.Dtos.Curso;
using FluentValidation;

namespace CursoAPi.Validations;

public class CursoValidator : AbstractValidator<CreateCursoDto>
{
    public CursoValidator()
    {
        // Valida o Nome
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O nome do curso é obrigatório.")
            .MinimumLength(3).WithMessage("O nome do curso deve ter no mínimo 3 caracteres.");

        // Valida a Descrição
        RuleFor(c => c.Descricao)
            .NotEmpty().WithMessage("A descrição do curso é obrigatória.")
            .MinimumLength(10).WithMessage("A descrição deve ter no mínimo 10 caracteres.");

        // Valida a Carga Horária
        RuleFor(c => c.CargaHoraria)
            .GreaterThan(0).WithMessage("A carga horária deve ser maior que zero.");

        // Valida o Nível
        RuleFor(c => c.Nivel)
            .NotEmpty().WithMessage("O nível do curso é obrigatório.");

        // Valida o Preço
        RuleFor(c => c.Preco)
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

        // Valida o status Ativo
        RuleFor(c => c.Ativo)
            .NotNull().WithMessage("O status do curso (ativo ou não) é obrigatório.");
    }
}
