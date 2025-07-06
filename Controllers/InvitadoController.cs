using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiSystemControlAccess;

namespace WebApiSystemControlAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvitadoController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint para registrar un nuevo invitado
        [HttpPost("registrar")]
        public IActionResult RegistrarInvitado([FromBody] invitadoDto invitadoDto)
        {
            // Validamos que el modelo sea válido
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Crear nuevo invitado
            var nuevoInvitado = new Invitado
            {
                nombre = invitadoDto.nombre,
                apellido_paterno = invitadoDto.apellido_paterno,
                apellido_materno = invitadoDto.apellido_materno,
                fecha_vigencia = invitadoDto.fecha_vigencia,
              id_usuario = invitadoDto.id_usuario,
                tipo_invitacion = invitadoDto.tipo_invitacion // Cambiado a tipo_invitacion
            };

            // Agregar el nuevo invitado a la base de datos
            _context.Invitados.Add(nuevoInvitado);
            _context.SaveChanges();

            // Retornar la respuesta con el mensaje y el ID del invitado
            return Ok(new { mensaje = "Invitado registrado correctamente", invitadoId = nuevoInvitado.id_invitado });
        }

        // Endpoint para obtener todos los invitados
        [HttpGet("usuario/{idUsuario}")]
        public IActionResult ObtenerPorUsuario(int idUsuario)
        {
            var invitados = _context.Invitados
                .Where(i => i.id_usuario == idUsuario)
                .Select(i => new
                {
                    i.id_invitado,
                    i.nombre,
                    i.apellido_paterno,
                    i.apellido_materno,
                    i.fecha_vigencia,
                    i.id_usuario,
                    i.tipo_invitacion,
                    estado = i.fecha_vigencia > DateTime.Now
                        ? (i.fecha_vigencia.Date == DateTime.Today ? "Activo" : "Pendiente")
                        : "Vencido"
                })
                .ToList();

            return Ok(invitados);
        }


        // Endpoint para obtener los tipos de invitación
        [HttpGet("tipos-invitacion")]
        public IActionResult ObtenerTiposInvitacion()
        {
            var tiposInvitacion = new List<string> { "única", "por fecha", "recurrente" };
            return Ok(tiposInvitacion);
        }
        [HttpGet("mis-invitados/{idUsuario}")]
        public IActionResult ObtenerMisInvitados(int idUsuario)
        {
            var ahora = DateTime.Now;

            var invitados = _context.Invitados
                .Where(i => i.id_usuario == idUsuario)
                .Select(i => new
                {
                    i.id_invitado,
                    nombre = $"{i.nombre} {i.apellido_paterno} {i.apellido_materno}",
                    fecha = i.fecha_vigencia,
                    estado = i.fecha_vigencia > ahora
                        ? (i.fecha_vigencia.Date == ahora.Date ? "Activo" : "Pendiente")
                        : "Vencido"
                })
                .ToList();

            return Ok(invitados);
        }
    }
}
