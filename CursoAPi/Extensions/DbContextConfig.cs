using CursoAPi.Data;
using Microsoft.EntityFrameworkCore;

public static class DbContextConfig
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CursoContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 36))));

        return services;
    }
}
