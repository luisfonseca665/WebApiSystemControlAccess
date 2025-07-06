using System.ComponentModel.DataAnnotations.Schema;
namespace WebApiSystemControlAccess
{
    public class UsuarioLoginDto
    {
        public string usuario { get; set; }
        public string Password { get; set; }
    }
}
