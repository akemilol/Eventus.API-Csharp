using System.ComponentModel.DataAnnotations;

namespace Eventus.API.Application.Dtos

{
    public class UsuarioLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
