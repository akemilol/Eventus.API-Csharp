namespace Eventus.API.Application.Dtos

{
    public class UsuarioAlertaCreateDto
    {
        public int UsuarioIdUsuario { get; set; }
        public int AlertasId { get; set; }
        public DateTime? DataRecebimento { get; set; }
    }
}
