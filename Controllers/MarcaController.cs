using BikeDrivers.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeDrivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly BIKE_DRIVERSContext context;

        public MarcaController(BIKE_DRIVERSContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> TraerMarcas()
        {
            var marcas = await context.Marcas.ToListAsync();

            return marcas;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> TraerMarcaPorId(int id)
        {
            var marca = await context.Marcas.FindAsync(id);

            if(marca == null)
            {
                return NotFound();
            }

            return Ok(marca);   
        }

        [HttpPost]
        public async Task<ActionResult> CrearMarca(Marca marca)
        {
            context.Marcas.Add(marca);  
            await context.SaveChangesAsync();
            return Ok(marca);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarMarca(int id)
        {
            var marca = await context.Marcas.FindAsync(id); 

            if (marca == null)
            {
                return NotFound($"La marca con el id {id} no existe");
            }
            context.Remove(marca);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
