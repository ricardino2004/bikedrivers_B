using BikeDrivers.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeDrivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly BIKE_DRIVERSContext context;
        public UsuariosController(BIKE_DRIVERSContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> TraerUsuarios()
        {
            var usuarios = await context.Usuarios.ToListAsync();

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> TraerUsuariosPorId(int id)
        {
            var usuarios = await context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult> CrearUsuarios(Usuario usuarios)
        {
            context.Usuarios.Add(usuarios);
            await context.SaveChangesAsync();
            return Ok(usuarios);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarUsuarios(int id)
        {
            var usuarios = await context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound($"El usuario con el id {id} no existe");
            }
            context.Remove(usuarios);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
