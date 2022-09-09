using BikeDrivers.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeDrivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly BIKE_DRIVERSContext context;
        public ProveedorController(BIKE_DRIVERSContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Provedor>>> TraerProvedor()
        {
            var proveedor = await context.Provedors.ToListAsync();

            return proveedor;
        }
        [HttpGet("{id}")]
            public async Task<ActionResult<Provedor>> TraerProvedorPorId(int id)
            {
                var proveedor = await context.Provedors.FindAsync(id);

                if (proveedor == null)
                {
                    return NotFound();
                }

                return Ok(proveedor);
        }

        [HttpPost]
        public async Task<ActionResult> CrearProvedor(Provedor proveedor)
        {
            context.Provedors.Add(proveedor);
            await context.SaveChangesAsync();
            return Ok(proveedor);
        }
        [HttpDelete("{id}")]

            public async Task<ActionResult> BorrarProvedor(int id)
            {
                var proveedor = await context.Provedors.FindAsync(id);

                if (proveedor == null)
                {
                    return NotFound($"El proveedor con el id {id} no existe");
                }
                context.Remove(proveedor);
                await context.SaveChangesAsync();
                return NoContent();
            }
    }
}
