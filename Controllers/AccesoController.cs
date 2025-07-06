using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSystemControlAccess;

[ApiController]
[Route("api/[controller]")]
public class AccesoController : ControllerBase
{
    private readonly AppDbContext _context;

    public AccesoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/acceso/historial?id_usuario=3
    [HttpGet("historial")]
    public IActionResult GetHistorial([FromQuery] int? id_usuario)
    {
        var query = _context.HistorialAccesos
            .Include(h => h.Usuario)
            .AsQueryable();

        if (id_usuario.HasValue)
        {
            query = query.Where(h => h.Id_Usuario == id_usuario.Value);
        }

        var resultado = query
            .OrderByDescending(h => h.Fecha_Entrada)
            .Select(h => new
            {
                nombre = h.Usuario.usuario, // Cambia por el nombre correcto si es necesario
                fechaEntrada = h.Fecha_Entrada.ToString("yyyy-MM-dd HH:mm"),
                fechaSalida = h.Fecha_Salida.HasValue ? h.Fecha_Salida.Value.ToString("yyyy-MM-dd HH:mm") : "En curso",
                autorizado = h.Fecha_Salida == null
            })
            .ToList();

        return Ok(resultado);
    }
}
