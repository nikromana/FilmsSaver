using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace FilmsSaverDbContext
{
    public class FilmsSaverDbContext : IdentityDbContext<User>
    {
        public FilmsSaverDbContext(DbContextOptions<FilmsSaverDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Film> Films { get; set; }
    }

}
