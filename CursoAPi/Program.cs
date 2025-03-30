var builder = WebApplication.CreateBuilder(args);

// Configura��o do AutoMapper
builder.Services.AddAutoMapperConfig(); // Adiciona o AutoMapper

// Configura��o do DbContext (Banco de Dados)
builder.Services.AddDatabaseConfig(builder.Configuration); // Adiciona o DbContext

// Configura��o do FluentValidation
builder.Services.AddFluentValidationConfig(); // Adiciona o FluentValidation

// Configura��es b�sicas da aplica��o
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��o do Swagger (se necess�rio)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
