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
        public IActionResult Login([FromBody] Usuario user)
        {
            if (user == null || string.IsNullOrEmpty(user.usuario) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Datos incompletos");
            }

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.usuario == user.usuario && u.Password == user.Password);

            if (usuario == null)
                return Unauthorized("Credenciales inválidas");

            return Ok(new
            {
                mensaje = "Login exitoso",
                id = usuario.Id,
                usuario = usuario.usuario
            });
        }
    }
}

