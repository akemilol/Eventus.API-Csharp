namespace Eventus.API.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string DataNascimento { get; set; }
    }
}
