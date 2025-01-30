using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FilmsSaverDbContext
{
    public class FilmsSaverDbContextFactory : IDesignTimeDbContextFactory<FilmsSaverDbContext>
    {
        public FilmsSaverDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FilmsSaverDbContext>();

            // Читаем строку подключения из файла конфигурации
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new FilmsSaverDbContext(optionsBuilder.Options);
        }
    }
}