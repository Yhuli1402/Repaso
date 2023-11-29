using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsLibro;

namespace WebApplication2.ControllersLibro
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILogger<LibroController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public LibroController(
            ILogger<LibroController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // CREATE: Crear materia
        [HttpPost(Name = "PostLibro")]
        public IActionResult Post([FromBody] Libro libro)
        {
            _aplicacionContexto.Libro.Add(libro);
            _aplicacionContexto.SaveChanges();
            return Ok(libro);
        }

        // READ: Obtener lista de materias
        [HttpGet(Name = "GetLibro")]
        public IEnumerable<Libro> Get()
        {
            return _aplicacionContexto.Libro.ToList();
        }

        // UPDATE: Modificar materia
        [HttpPut(Name = "PutLibro")]
        public IActionResult Put([FromBody] Libro libro)
        {
            _aplicacionContexto.Libro.Update(libro);
            _aplicacionContexto.SaveChanges();
            return Ok(libro);
        }

        // DELETE: Eliminar materia
        [HttpDelete(Name = "DeleteLibro")]
        public IActionResult Delete(int libroId)
        {
            var libro = _aplicacionContexto.Libro
                .FirstOrDefault(x => x.IdLibro == libroId);

            if (libro != null)
            {
                _aplicacionContexto.Libro.Remove(libro);
                _aplicacionContexto.SaveChanges();
                return Ok(libroId);
            }
            else
            {
                return NotFound($"Libro con Id {libroId} no encontrada.");
            }
        }
    }
}
