using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiSystemControlAccess;

namespace WebApiSystemControlAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginDto userLogin)
        {
            if (userLogin == null || string.IsNullOrEmpty(userLogin.usuario) || string.IsNullOrEmpty(userLogin.Password))
            {
                return BadRequest("Datos incompletos");
            }

            var usuarioDb = _context.Usuarios
                .FirstOrDefault(u => u.usuario == userLogin.usuario && u.Password == userLogin.Password);

            if (usuarioDb == null)
                return Unauthorized("Credenciales inválidas");

            string imagenBase64 = usuarioDb.imagen != null
                ? Convert.ToBase64String(usuarioDb.imagen)
                : null;

            return Ok(new
            {
                mensaje = "Login exitoso",
                id = usuarioDb.Id,
                usuario = usuarioDb.usuario,
                imagen = imagenBase64
            });
        }
    }
}


