using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.ModelsGenero;

namespace WebApplication2.ControllersGenero
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : ControllerBase
    {
    
        private readonly ILogger<GeneroController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public GeneroController(
            ILogger<GeneroController> logger, 
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [HttpPost(Name = "PostGenero")]
        public IActionResult Post(
            [FromBody] Genero genero)
        {
            _aplicacionContexto.Genero.Add(genero);
            _aplicacionContexto.SaveChanges();
            return Ok(genero);
        }
        //READ: Obtener lista de estudiantes
        [HttpGet(Name = "GetGenero")]
        public IEnumerable<Genero> Get()
        {
            return _aplicacionContexto.Genero.ToList();
        }

        //Update: Modificar estudiantes
        [HttpPut(Name = "PutGenero")]
        public IActionResult Put([FromBody] Genero genero)
        {
            _aplicacionContexto.Genero.Update(genero);
            _aplicacionContexto.SaveChanges();
            return Ok(genero );
        }

        //Delete: Eliminar estudiantes
        [HttpDelete(Name = "DeleteGenero")]
        public IActionResult Delete(int GeneroId)
        {
            _aplicacionContexto.Genero.Remove(
                _aplicacionContexto.Genero.ToList()
                .Where(x => x.IdGenero == GeneroId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges ();
            return Ok(GeneroId);
        }
    }
}