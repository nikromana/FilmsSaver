using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace FilmsSaverDbContext
{
    public class FilmsSaverDbContext : DbContext
    {
        public FilmsSaverDbContext(DbContextOptions<FilmsSaverDbContext> options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
    }

}
