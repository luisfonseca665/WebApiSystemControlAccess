
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSystemControlAccess
{
    [Table("historiales")]   // Indica el nombre real de la tabla en la base de datos
    public class HistorialAcceso
    {
        [Key]
        public int Id_Historial { get; set; }

        public DateTime Fecha_Entrada { get; set; }
        public DateTime? Fecha_Salida { get; set; }

        public int Id_Usuario { get; set; }

        [ForeignKey("Id_Usuario")]
        public Usuario Usuario { get; set; }
    }
}

