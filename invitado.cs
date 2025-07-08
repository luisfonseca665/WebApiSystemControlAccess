using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Invitados")] // ¡Este nombre debe coincidir exactamente con el de SQL Server!
public class Invitado
{
    [Key]
    public int id_invitado { get; set; }

    public string nombre { get; set; }

    public string apellido_paterno { get; set; }

    public string apellido_materno {get; set; }

    public DateTime fecha_vigencia { get; set; }

    public int id_usuario { get; set; }

    public string tipo_invitacion { get; set; }
    public string? estatus { get; set; } // Este campo es opcional, pero puede ser útil para el estado del invitado
}
