using Microsoft.EntityFrameworkCore;
using WebApplication2.ModelsGenero;
using WebApplication2.ModelsLibro;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Libro> Libro { get; set; }
    }
}
