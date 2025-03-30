var builder = WebApplication.CreateBuilder(args);

// Configuração do AutoMapper
builder.Services.AddAutoMapperConfig(); // Adiciona o AutoMapper

// Configuração do DbContext (Banco de Dados)
builder.Services.AddDatabaseConfig(builder.Configuration); // Adiciona o DbContext

// Configuração do FluentValidation
builder.Services.AddFluentValidationConfig(); // Adiciona o FluentValidation

// Configurações básicas da aplicação
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do Swagger (se necessário)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
