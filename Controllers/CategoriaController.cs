    using BikeDrivers.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeDrivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly BIKE_DRIVERSContext context;

        public CategoriaController(BIKE_DRIVERSContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Categorium>>> TraerCategorias()
        {
            var categorias = await context.Categoria.ToListAsync(); 

            return categorias;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorium>> TraerCategoriaPorId(int id)
        {
            var categorias = await context.Categoria.FindAsync(id);

            if (categorias == null)
            {
                return NotFound();
            }

            return Ok(categorias);
        }

        [HttpPost]
            public async Task<ActionResult> CrearCategoria(Categorium categorias)
            {
            _ = context.Categoria.Add(categorias);
                await context.SaveChangesAsync();
                return Ok(categorias);
        }

        [HttpDelete("{id}")]
            public async Task<ActionResult> BorrarCategoria(int id)
            {
                var categorias = await context.Categoria.FindAsync(id);

                if (categorias == null)
                {
                    return NotFound($"La categoria con el id {id} no existe");
                }
                context.Remove(categorias);
                await context.SaveChangesAsync();
                return NoContent();
            }
        
    }
}
