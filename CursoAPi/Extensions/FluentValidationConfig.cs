using CursoAPi.Data.Dtos.Aluno;
using CursoAPi.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

public static class FluentValidationConfig
{
    public static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
    {
        // Registra o FluentValidation com validação automática no servidor e adaptação para clientes
        services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        // Registra os validadores automaticamente a partir da assembly que contém a classe Program
        services.AddValidatorsFromAssemblyContaining<Program>();

        // Registrando o validador explicitamente (opcional, caso precise)
        services.AddScoped<IValidator<CreateAlunoDto>, AlunoValidator>();

        return services;
    }
}
