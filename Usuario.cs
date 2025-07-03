using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSystemControlAccess
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("usuario")]
        public string usuario { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}
