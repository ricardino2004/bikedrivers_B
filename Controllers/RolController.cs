using BikeDrivers.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeDrivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly BIKE_DRIVERSContext context;

        public RolController(BIKE_DRIVERSContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Rol>>> TraerRol()
        {
            var rol = await context.Rols.ToListAsync();

            return rol;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> TraerRolPorId(int id)
        {
            var rol = await context.Rols.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }
        [HttpPost]
        public async Task<ActionResult> CrearRol(Rol rol)
        {
            context.Rols.Add(rol);
            await context.SaveChangesAsync();
            return Ok(rol);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarRol(int id)
        {
            var rol = await context.Rols.FindAsync(id);

            if (rol == null)
            {
                return NotFound($"El rol con el id {id} no existe");
            }
            context.Remove(rol);
            await context.SaveChangesAsync();
            return NoContent();
        }
}
}
