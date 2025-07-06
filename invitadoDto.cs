using System;
using System.ComponentModel.DataAnnotations;

public class invitadoDto
{
    [Required]
    public string nombre { get; set; }

    [Required]
    public string apellido_paterno { get; set; }

    public string apellido_materno { get; set; }

    [Required]
    public DateTime fecha_vigencia { get; set; }

    [Required]
    public int id_usuario { get; set; }

    // Nuevo campo tipo_invitacion
    [Required]
    public string tipo_invitacion { get; set; }
}
