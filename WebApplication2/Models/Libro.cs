using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsLibro
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int IdGenero{ get; set; }
    }
}