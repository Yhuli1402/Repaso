using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsGenero
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        public string Nombre { get; set; }
       
    }
}