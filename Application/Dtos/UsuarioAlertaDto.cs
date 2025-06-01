namespace Eventus.API_Csharp.Application.Dtos
{
    public class UsuarioAlertaDto
    {
        public int Id { get; set; }
        public int UsuarioIdUsuario { get; set; }
        public int AlertasId { get; set; }
        public DateTime? DataRecebimento { get; set; }
    }
}
