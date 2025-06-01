using System.ComponentModel.DataAnnotations;

namespace Eventus.API.Application.Dtos
{
    public class UsuarioCreateDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Senha { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
