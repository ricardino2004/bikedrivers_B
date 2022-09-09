using BikeDrivers.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeDrivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly BIKE_DRIVERSContext context;

        public ProductoController(BIKE_DRIVERSContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Producto>>> TraerProductos()
        {
            var productos = await context.Productos.ToListAsync();  

            return productos;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> TraerProductosPorId(int id)
        {
            var producto = await context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }


        [HttpPost]
        public async Task<ActionResult> CrearProducto(Producto producto)
        {
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return Ok(producto);

        }
        [HttpDelete("{id}")]
            public async Task<ActionResult> BorrarProductos(int id)
            {
                var producto = await context.Productos.FindAsync(id);

                if (producto == null)
                {
                    return NotFound($"El producto con el id {id} no existe");
                }
                context.Remove(producto);
                await context.SaveChangesAsync();
                return NoContent();
            }
    }

}
